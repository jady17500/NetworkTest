 using Cinemachine;
using StarterAssets;
using Unity.Netcode;
using UnityEngine;

public class ClientFollowCamera : MonoBehaviour
{
    
    public GameObject mainCamera;
    public Transform cameraTarget;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SpawnCamera()
    {
        var camera= Instantiate(mainCamera, cameraTarget.transform.position, Quaternion.identity);
        gameObject.GetComponent<ThirdPersonController>().mainCamera = camera;
        camera.transform.Rotate(90f,0,0);
        camera.GetComponent<TopDownCamera>().target = cameraTarget;
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
