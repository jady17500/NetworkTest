using Unity.Netcode;
using UnityEngine;

public class WeaponScript : NetworkBehaviour
{
    public Transform MuzzleTransform;
    public GameObject BulletPrefab;
    public AudioSource BulletSound;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   
    }
    
    [Rpc(SendTo.Server)]
    public void FireRpc()
    {
        SpawnBullet();
    }



    
    public void SpawnBullet()
    {
            var instance=Instantiate(BulletPrefab, MuzzleTransform.position, MuzzleTransform.rotation);
            instance.GetComponent<NetworkObject>().Spawn();
            
    }
    
    [Rpc(SendTo.ClientsAndHost)]
    public void SoundRpc()
    {
        BulletSound.Play();
    }
    
}
