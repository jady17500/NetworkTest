using System.Collections;
using Unity.Netcode;
using UnityEngine;

public class NetworkHealthComponent : NetworkBehaviour
{
    public NetworkVariable<float> maxHealth = new NetworkVariable<float>(100f);
    public NetworkVariable<float> currentHealth = new NetworkVariable<float>();


    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        if(IsServer)    
            currentHealth.Value = maxHealth.Value;
    }


    public void TakeDamage(int damage)
    {
        print("Damage");
        currentHealth.Value -= damage;
        currentHealth.Value = Mathf.Clamp(currentHealth.Value, 0, maxHealth.Value);
        UiUpdateRpc();
        if (currentHealth.Value <= 0)
        {
            DeathRpc();
        }
    }

    public void Heal(float heal)
    {
        currentHealth.Value += heal;
        currentHealth.Value = Mathf.Clamp(currentHealth.Value, 0, maxHealth.Value);
        UiUpdateRpc();
        
    }

    [Rpc(SendTo.Owner)]
    public void DeathRpc()
    {
        print("DEAD");
        
        
        StartCoroutine(DeathSequence());

    }

    [Rpc(SendTo.Owner)]
    public void UiUpdateRpc()
    {
        GetComponent<ClientUi>().ui.GetComponentInChildren<UIManager>().SetHealth(currentHealth.Value/maxHealth.Value);
    }

    public IEnumerator DeathSequence()
    {
        GetComponent<ClientUi>().ui.GetComponentInChildren<UIManager>().SwitchMode(1);
        DisableMeshRpc();
        GetComponent<ClientPlayerMove>().ToggleInputs(false);
        float deathTime = 5;
        
        while (deathTime >= 0f) 
        {
            deathTime -= Time.deltaTime;
            GetComponent<ClientUi>().ui.GetComponentInChildren<UIManager>().UpdateDeathText(Mathf.RoundToInt(deathTime));
            
            yield return null;
        }
        
        GetComponent<ClientUi>().ui.GetComponentInChildren<UIManager>().SwitchMode(0);
        GetComponent<ClientPlayerMove>().ToggleInputs(true);
        ActivateMeshRpc();
        GetComponent<ClientSpawn>().SpawnPlayer();
        Heal(100f);
    }


    [Rpc(SendTo.ClientsAndHost)]
    public void DisableMeshRpc()
    {
        foreach (var mesh in GetComponentsInChildren<MeshRenderer>())
        {
            mesh.enabled = false;
        }
    }

    [Rpc(SendTo.ClientsAndHost)]
    public void ActivateMeshRpc()
    {
        foreach (var mesh in GetComponentsInChildren<MeshRenderer>())
        {
            mesh.enabled = true;
            if(mesh.gameObject.name=="FOV_Visual"&& !IsOwner)
                mesh.enabled = false;
        }
    }
    
    
}
