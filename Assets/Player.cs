using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private Vector2 _direction;
    public void SetDirection(Vector2 dir)
    {
        _direction = dir;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_direction.magnitude > 0)
        {
            var newposition = _direction * _speed * Time.deltaTime;
            transform.position += new Vector3(newposition.x, newposition.y, transform.position.z);
        }
    }
}
