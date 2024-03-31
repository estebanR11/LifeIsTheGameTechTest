using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private SOWeapon scriptableWeapon;
    [SerializeField] private Transform firePoint;
    bool isEquipped = false;
    float nextFireTime;

    private void Start()
    {
        
    }
    private void Update()
    {
        if (isEquipped)
        {
            if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + 1f / scriptableWeapon.fireRate;
            }
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(scriptableWeapon.bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(firePoint.forward * scriptableWeapon.range, ForceMode.Impulse);
        }
    }

    public void SetEquipped(bool isItemEquipped)
    {
        isEquipped = isItemEquipped;
    }
}
