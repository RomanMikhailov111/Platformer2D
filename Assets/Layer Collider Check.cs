﻿using System.Collections;
using UnityEngine;

namespace Assets
{
    public class LayerColliderCheck : LayerCheck
    {
        [SerializeField]
        private Collider2D _collider;

        private void OnTriggerStay2D(Collider2D collision)
        {
            IsTouchingLayer = _collider.IsTouchingLayers(checkLayerMask);
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            IsTouchingLayer = _collider.IsTouchingLayers(checkLayerMask);
        }
    }
}