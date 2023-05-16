using UnityEngine;

public class PickUp : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _))
        {
            gameObject.SetActive(false);
        }
    }
}
