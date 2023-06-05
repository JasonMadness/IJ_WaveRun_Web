using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EndScreen : MonoBehaviour
{
    private Animator _animator;

    private const string SHOW = "Show";
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Reveal()
    {
        _animator.SetTrigger(SHOW);
    }
}
