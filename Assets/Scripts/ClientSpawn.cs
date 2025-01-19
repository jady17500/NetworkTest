using Unity.Netcode;
using UnityEngine;

public class ClientSpawn : NetworkBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        transform.position = SpawnManager.instance.GetRandomSpawnPoint().position;
    }
}
