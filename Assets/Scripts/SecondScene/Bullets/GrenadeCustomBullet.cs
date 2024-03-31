using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeCustomBullet : MonoBehaviour
{
    [SerializeField] private float explosionRadius = 5f;
    [SerializeField] private float explosionForce = 1000f;
    [SerializeField] private float fuseTime = 3f;
    [SerializeField] private float destroyDelay = 0.5f; 

    private bool hasExploded = false;

    void Start()
    {
        Invoke("Explode", fuseTime); 
    }

    void Explode()
    {
        if (!hasExploded)
        {
            hasExploded = true;

            Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

            foreach (Collider col in colliders)
            {
                Rigidbody rb = col.GetComponent<Rigidbody>();
                if (rb != null && col.CompareTag("GravityAffected"))
                {
                    rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
                }
            }

            Invoke("DestroyGrenade", destroyDelay);
        }
    }
    void DestroyGrenade()
    {
        Destroy(gameObject);
    }
}
