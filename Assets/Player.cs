using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _jumpSpeed;
    [SerializeField] 
    private LayerMask _groundLayer;
    [SerializeField]
    private Rigidbody2D _rigidbody2d;

    private Vector2 _direction;
    public void SetDirection(Vector2 dir)
    {
        _direction = dir;
    }

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        _rigidbody2d.velocity = new Vector2(_direction.x * _speed, _rigidbody2d.velocity.y);

        bool isJumping = _direction.y > 0;
        if (isJumping && IsGrounded())
        {
            _rigidbody2d.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);

        }
    }

    private bool IsGrounded()
    {
        var hit = Physics2D.Raycast(transform.position, Vector2.down, 1, _groundLayer);
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, Vector2.down, IsGrounded() ? Color.green : Color.red);
    }
}
