using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]private float maxDist = 5f;
    [SerializeField] private KeyCode interactKey = KeyCode.E; 
    Camera mainCamera;
    GameObject actualWeapon;
    [SerializeField] private Transform weaponTransform;
    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {

        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDist))
        {

            if(hit.collider.gameObject.tag =="Weapon" && Input.GetKeyDown(interactKey))
            {
                if (actualWeapon !=null)
                {
                    actualWeapon.transform.SetParent(null);
                    actualWeapon = null;
                }
                actualWeapon = hit.collider.gameObject;
                actualWeapon.transform.SetParent(weaponTransform);
                actualWeapon.transform.localPosition = new Vector3(0,0,0);
                actualWeapon.transform.localRotation = Quaternion.identity;

            }

            
        }
    }
}
