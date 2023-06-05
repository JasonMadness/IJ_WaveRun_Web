using UnityEngine;

public class EndScreen : MonoBehaviour
{
    public void Reveal()
    {
        GetComponent<Animator>().SetTrigger("Show");
    }
}
