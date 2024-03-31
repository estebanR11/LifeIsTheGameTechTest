using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]private float maxDist = 5f;
    [SerializeField] private KeyCode interactKey = KeyCode.E; 
    Camera mainCamera;
    GameObject equippedWeapon;
    [SerializeField] private Transform weaponTransform;
    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKeyDown(interactKey))
            TryInteractWithWeapon();
    }

    private void TryInteractWithWeapon()
    {
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if (Physics.Raycast(ray, out RaycastHit hit, maxDist))
        {
            if (hit.collider.CompareTag("Weapon"))
                InteractWithWeapon(hit.collider.gameObject.GetComponent<Rigidbody>());
        }
    }

    private void InteractWithWeapon(Rigidbody weaponRigidbody)
    {
        if (equippedWeapon != null)
            UnequipCurrentWeapon();

        equippedWeapon = weaponRigidbody.gameObject;
        equippedWeapon.transform.SetParent(weaponTransform);
        equippedWeapon.transform.localPosition = Vector3.zero;
        equippedWeapon.transform.localRotation = Quaternion.identity;
        equippedWeapon.GetComponent<Weapon>().SetEquipped(true);
        weaponRigidbody.isKinematic = true;
    }

    private void UnequipCurrentWeapon()
    {
        equippedWeapon.GetComponent<Rigidbody>().isKinematic = false;
        equippedWeapon.GetComponent<Weapon>().SetEquipped(false);
        equippedWeapon.transform.SetParent(null);
        equippedWeapon = null;
    }
}
