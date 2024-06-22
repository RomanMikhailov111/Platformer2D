using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField]
    private Collider2D DoorCollider2D;
    private static readonly int Property = Animator.StringToHash("isOpened");

    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private bool _state;

    [ContextMenu("SwitchInteract")]
    public void SwitchInteract()
    {
        _state = !_state;
        DoorCollider2D.enabled = !_state;
        _animator.SetBool(Property, _state);
    }
}