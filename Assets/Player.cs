using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const float OFFSET = 0.5f;

    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _jumpSpeed;
    [SerializeField]
    private Rigidbody2D _rigidbody2d;

    [SerializeField]
    private Vector3 _offsetVectorCast;
    [SerializeField]
    private float _radiusCast;
    [SerializeField]
    private float _distanceCast;
    [SerializeField]
    private LayerMask _groundLayer;

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
        bool isGrounded = IsGrounded();
        if (isJumping && isGrounded)
        {
            _rigidbody2d.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);

        }
    }

    private bool IsGrounded()
    {
        var hit = Physics2D.CircleCast(transform.position + _offsetVectorCast, _radiusCast, Vector2.down, _distanceCast, _groundLayer);
        return hit.collider != null;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = IsGrounded() ? Color.green : Color.red;
        Gizmos.DrawSphere(transform.position + _offsetVectorCast, _radiusCast);
    }
}
