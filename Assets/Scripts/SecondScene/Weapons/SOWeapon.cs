using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewWeapon", menuName = "Weapons/Weapon")]

public class SOWeapon : ScriptableObject
{
    public GameObject bulletPrefab;
    public float fireRate;
    public int damage;
    public float range;
}
