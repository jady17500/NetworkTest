using Unity.Netcode;
using UnityEngine;

public class SetPlayerColour : NetworkBehaviour
{
    public Color allyColour;
    public Color enemyColour;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        print("Player Spawned");
        if (IsOwner)
        {
            GetComponent<MeshRenderer>().material.color = allyColour;
        }
        else
        {
            GetComponent<MeshRenderer>().material.color = enemyColour;
        }
    }
}
