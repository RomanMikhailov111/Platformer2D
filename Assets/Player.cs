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

    [SerializeField]
    private int _coins;

    private Vector2 _direction;

    private bool _allowDoubleJump;
    public void SetDirection(Vector2 dir)
    {
        _direction = dir;
    }
    public void AddCoin(int value)
    {
        _coins += value;
        Debug.Log("Collect coin : " + value + ". All coins : " + _coins);
    }

    void Update()
    {
        /*_animator.SetBool("is-grounded", _groundCheck.IsTouchingLayer);
        _animator.SetBool("is-running", _direction.x!=0);
        _animator.SetFloat("vertical-velocity", _rigidbody2d.velocity.y);*/
    }

    void FixedUpdate()
    {
        float xvelocity = _direction.x * _speed;
        float yvelocity = CalculateYVelocity();

        _rigidbody2d.velocity = new Vector2(xvelocity, yvelocity);

        _animator.SetBool("is-grounded", _groundCheck.IsTouchingLayer);
        _animator.SetBool("is-running", _direction.x != 0);
        _animator.SetFloat("vertical-velocity", _rigidbody2d.velocity.y);

        UpdateSpriteDirection();
    }

    private void UpdateSpriteDirection()
    {
        if (_direction.x > 0)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
        else if (_direction.x < 0)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
    }

    private float CalculateYVelocity()
    {
        float yvelocity = _rigidbody2d.velocity.y;
        bool isJumping = _direction.y > 0;
        bool isGrounded = _groundCheck.IsTouchingLayer;

        if (isGrounded)
        {
            _allowDoubleJump = true;
        }

        if (isJumping)
        {
            yvelocity = CalculateJumpVelocity(yvelocity);
        }
        else if (yvelocity > 0) 
        {
            yvelocity *= 0.5f;
        }
        return yvelocity;
    }

    private float CalculateJumpVelocity(float yvelocity)
    {
        bool isFalling = _rigidbody2d.velocity.y <= 0.001f;
        bool isGrounded = _groundCheck.IsTouchingLayer;

        if (!isFalling)
        {
            return yvelocity;
        }
        if (isGrounded) 
        {
            yvelocity += _jumpSpeed;
        }
        else if (_allowDoubleJump)
        {
            yvelocity = _jumpSpeed;
            _allowDoubleJump = false;
        }

        return yvelocity;
    }
}
