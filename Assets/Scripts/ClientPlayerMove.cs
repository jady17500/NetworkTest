using StarterAssets;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClientPlayerMove : NetworkBehaviour
{

    [SerializeField] private PlayerInput playerInputs;
    [SerializeField] private StarterAssetsInputs starterInputs;
    [SerializeField] private ThirdPersonController thirdPersonController;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerInputs.enabled = false;
        starterInputs.enabled = false;
        thirdPersonController.enabled = false;
    }

    // Update is called once per frame
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        if (IsOwner)
        {
            starterInputs.enabled = true;
            playerInputs.enabled = true;
            thirdPersonController.enabled = true;
        }
    }
}
