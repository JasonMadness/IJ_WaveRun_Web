using System;
using UnityEngine;

public class FinishBonus : MonoBehaviour
{
    public event Action Destroyed;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _))
        {
            Destroyed?.Invoke();
        }
    }
}
