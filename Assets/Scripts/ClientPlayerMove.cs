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
        ToggleInputs(false);
    }

    // Update is called once per frame
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        if (IsOwner)
        {
            ToggleInputs(true);
            gameObject.GetComponent<ClientFollowCamera>().SpawnCamera();
        }
    }


    public void ToggleInputs(bool toggle)
    {
        starterInputs.enabled = toggle;
        playerInputs.enabled = toggle;
        thirdPersonController.enabled = toggle;
    }
}
