using System;
using StarterAssets;
using UnityEngine;

public class OfflineCamera : MonoBehaviour
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

    private void Start()
    {
        SpawnCamera();
    }
}
