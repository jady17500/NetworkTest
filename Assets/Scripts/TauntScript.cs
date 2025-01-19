using Unity.Netcode;
using UnityEngine;

public class TauntScript : NetworkBehaviour
{
    public AudioSource audioSource;

    [Rpc(SendTo.ClientsAndHost)]
    public void TauntRpc()
    {
        audioSource.Play();
    }
}
