using Unity.Netcode;
using UnityEngine;

public class ClientDeactivateFov : NetworkBehaviour
{
    public MeshRenderer fovRenderer;
    
    
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        if (IsOwner)
        {
            fovRenderer.enabled = true;
        }
        else
        {
            fovRenderer.enabled = false;
        }
    }
}
