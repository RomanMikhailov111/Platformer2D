using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets
{
    [Serializable]

    public class EnterEvent:UnityEvent<GameObject>
    {
    }
}