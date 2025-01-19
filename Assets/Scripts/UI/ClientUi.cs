using Unity.Netcode;
using UnityEngine;

public class ClientUi : NetworkBehaviour
{
    public GameObject UiPrefab;
    public GameObject ui;

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        if (IsOwner)
        {
            ui = Instantiate(UiPrefab, Vector3.zero, Quaternion.identity);
            ui.GetComponentInChildren<UIManager>().SetOwner(gameObject);
            ui.GetComponentInChildren<UIManager>().SwitchMode(0);
            ui.GetComponentInChildren<UIManager>().SetHealth(ui.GetComponentInChildren<UIManager>().owner.GetComponent<NetworkHealthComponent>().currentHealth.Value);
        }
    }
}
