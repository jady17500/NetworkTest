using Cinemachine;
using StarterAssets;
using Unity.Netcode;
using UnityEngine;

public class ClientFollowCamera : MonoBehaviour
{
    
    public GameObject PlayerFollowCameraObject;
    public GameObject mainCamera;
    public Transform cameraTarget;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SpawnCamera()
    {
        var instance = Instantiate(PlayerFollowCameraObject, gameObject.transform.position, Quaternion.identity);
        var camera= Instantiate(mainCamera, gameObject.transform.position, Quaternion.identity);
        
        
        gameObject.GetComponent<ThirdPersonController>().mainCamera = camera;
        instance.GetComponent<CinemachineVirtualCamera>().Follow = cameraTarget;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
