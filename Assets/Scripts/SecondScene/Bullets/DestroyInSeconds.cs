using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInSeconds : MonoBehaviour
{
    [SerializeField] float seconds = 5;

    private void Start()
    {
        Destroy(this.gameObject,seconds);
    }
}
