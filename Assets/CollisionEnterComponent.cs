using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEnterComponent : MonoBehaviour
{
    [SerializeField]
    private string _tag;

    [SerializeField]
    private EnterEvent _unityEvent;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(_tag))
        {
            _unityEvent?.Invoke(collision.gameObject);
        }
    }
}
