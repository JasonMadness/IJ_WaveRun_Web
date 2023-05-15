using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(typeof(PickUp), out _))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
