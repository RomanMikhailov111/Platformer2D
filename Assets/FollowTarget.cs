﻿using System.Collections;
using UnityEngine;

namespace Assets
{
    public class FollowTarget : MonoBehaviour
    {
        [SerializeField]
        private Transform _target;
        [SerializeField]
        private float _dumping;
        void LateUpdate()
        {
            var destination=new Vector3(_target.position.x,_target.position.y,transform.position.z);
            transform.position = Vector3.Lerp(transform.position, destination, Time.deltaTime * _dumping);
        }
    }
}