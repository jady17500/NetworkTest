using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    
    public Transform target;
    public float distance;
    private Vector3 targetPos;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetPos.y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            targetPos.y =target.transform.position.y+distance;
            targetPos.x = target.transform.position.x;
            targetPos.z = target.transform.position.z;
            transform.position = targetPos;            
        }

    }
}
