using System;
using System.Collections;
using Unity.Netcode;
using UnityEngine;

public class BulletScript : NetworkBehaviour
{

    public NetworkVariable<int> bulletDamage = new NetworkVariable<int>(25);
    public NetworkVariable<float> bulletSpeed = new NetworkVariable<float>(10f);
    public NetworkVariable<float> bulletLifeTime = new NetworkVariable<float>(10f);
    bool hasHit = false;
    
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        StartCoroutine(BulletTravelRoutine());
    }




    private IEnumerator BulletTravelRoutine()
    {
        float _t = 0f;
        Vector3 dir = transform.parent.forward;

        Vector3 pos = transform.parent.position;
        while (_t<bulletLifeTime.Value)
        {
            _t += Time.deltaTime;
            pos += dir*bulletSpeed.Value*Time.deltaTime;
            
            
            transform.parent.position = pos;
            yield return null;
        }
        GetComponentInParent<NetworkObject>().Despawn();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (!hasHit)
        {
            if (other.CompareTag("Player"))
            {
                print("Hit");
                
                other.GetComponent<NetworkHealthComponent>().TakeDamage(bulletDamage.Value);
                StopAllCoroutines();
                GetComponentInParent<NetworkObject>().Despawn();
                hasHit = true;
            }
            
        }
        
    }

    
    
    
}
