using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    
    public GameObject target;
    
    private Vector3 targetPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetPos.y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        targetPos.y =target.transform.position.y+10f;
        targetPos.x = target.transform.position.x;
        targetPos.z = target.transform.position.z;
        transform.position = targetPos;
    }
}
