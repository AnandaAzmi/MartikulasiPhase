using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 7f;
    [SerializeField]
    private float _jumpForce = 7f;

    private Rigidbody _rigidbody;
    private CapsuleCollider _collider;
    private Vector3 _velocity;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true;
        _collider = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        _velocity = new Vector3(0, _rigidbody.velocity.y, 0);

        if (Input.GetKey(KeyCode.W))
        {
            _velocity += Vector3.forward * _speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _velocity += Vector3.left * _speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _velocity += Vector3.back * _speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _velocity += Vector3.right * _speed;
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _velocity;
    }

    private bool IsGrounded()
    {
        if (Physics.Raycast(transform.position, Vector3.down, _collider.height / 2))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
