using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBullet : MonoBehaviour
{
    [SerializeField] private float attractionRadius = 5f;
    [SerializeField] private float attractionForce = 30f; 


    private void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, attractionRadius);

        foreach (Collider col in colliders)
        {
            
            if (col.CompareTag("GravityAffected") &&col.TryGetComponent(out Rigidbody rb) && col.gameObject != gameObject)
            {
                Vector3 attractionDirection = transform.position - col.transform.position;
                rb.AddForce(attractionDirection.normalized * attractionForce, ForceMode.Force);
                Vector3 rotationAxis = Vector3.Cross(attractionDirection.normalized, transform.forward);
                rb.MoveRotation(Quaternion.AngleAxis(5f, rotationAxis) * rb.rotation);
            }
        }
    }
}
