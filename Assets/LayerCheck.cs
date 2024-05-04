using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LayerCheck : MonoBehaviour
{
    public bool IsTouchingLayer;

    [SerializeField]
    protected LayerMask checkLayerMask;

}
