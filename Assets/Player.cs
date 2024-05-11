using Assets;
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
    private Animator _animator;

    [SerializeField]
    private LayerColliderCheck _groundCheck;

    private Vector2 _direction;

    public void SetDirection(Vector2 dir)
    {
        _direction = dir;
    }

    void Update()
    {
        _animator.SetBool("is-grounded", _groundCheck.IsTouchingLayer);
        _animator.SetBool("is-running", _direction.x!=0);
        _animator.SetFloat("vertical-velocity", _rigidbody2d.velocity.y);
    }

    void FixedUpdate()
    {
        _rigidbody2d.velocity = new Vector2(_direction.x * _speed, _rigidbody2d.velocity.y);
        bool isJumping = _direction.y > 0;
        bool isGrounded = _groundCheck.IsTouchingLayer;
        if (isJumping && isGrounded)
        {
            {
                _rigidbody2d.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
            }
        }
    }
}
