using System;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{

    [SerializeField] LayerMask layerMask;
    public float fov=90;
    public float viewDistance=50;
    public int rayCount=2;
    private Mesh mesh;
    Vector3 origin = Vector3.zero;
    float startAngle=0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float angle = startAngle;
        float angleIncrease = fov / rayCount;
        
        
        
        Vector3[] vertices = new Vector3[rayCount+1+1];
        Vector2[] uvs = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];
        
        vertices[0] = origin;
        
        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex = new Vector3();
            Physics.Raycast(origin, GetVectorFromAngle(angle)*viewDistance, out RaycastHit hit, layerMask);
            if (hit.collider != null)
                vertex = hit.point;
            else
                vertex = origin + GetVectorFromAngle(angle)*viewDistance;
                
            
            vertices[vertexIndex] = vertex;
            
            if (i > 0)
            {
                triangles[triangleIndex+0] = 0;
                triangles[triangleIndex+1] = vertexIndex-1;
                triangles[triangleIndex+2] = vertexIndex;
                triangleIndex += 3;
            }
            
            vertexIndex++;
            angle -= angleIncrease;
        }
        
        
        mesh.vertices = vertices;
        mesh.uv = uvs;
        mesh.triangles = triangles;
    }


    public Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    public float GetAngleFromVector(Vector3 vector)
    {
        vector=vector.normalized;
        float n = Mathf.Atan2(vector.y, vector.x)*Mathf.Rad2Deg;
        if(n<0)
            n+=360;

        return n;
    }
    
    
    
    public void SetAimDirection(Vector3 aimDirection)
    {
        startAngle = GetAngleFromVector(aimDirection)- fov /2f;
    }

    public void SetOrigin(Vector3 newOrigin)
    {
        origin = newOrigin;
    }
    
    
    
}
