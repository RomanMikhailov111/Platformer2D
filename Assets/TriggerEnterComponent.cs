using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets
{
    public class TriggerEnterComponent : MonoBehaviour
    {
        [SerializeField]
        private string _tag;

        [SerializeField]
        private EnterEvent _unityEvent;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag(_tag))
            {
                _unityEvent?.Invoke(collision.gameObject);
            }
        }
    }
}