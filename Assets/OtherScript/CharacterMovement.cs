using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private float _walkSpeed;
    [SerializeField]
    private float _sprintSpeed;
    [SerializeField]
    private float _jumpSpeed;
    [SerializeField]
    private float _rotationTime = 0.1f;
    [SerializeField]
    private Transform _groundChecker;
    [SerializeField]
    private float _groundCheckerRadius;
    [SerializeField]
    private LayerMask _groundLayer;


    private Rigidbody _rigidbody;
    private float _rotationVelocity;
    private float _speed;
    private Vector3 _velocity;
    private bool _isGrounded = true;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _speed = _walkSpeed;
    }

    private void Update()
    {
        HandleMoveInput();
        HandleSprintInput();
        HandleJumpInput();
        CheckIsGrounded();
        CheckPunchInput();
        _animator.SetFloat("VelocityY", _rigidbody.velocity.y);
        _velocity = _rigidbody.velocity;
    }

    private void HandleMoveInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 inputAxis = new Vector3(horizontal, 0, vertical);
        Move(inputAxis);
    }

    private void HandleSprintInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartSprint();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            StopSprint();
        }
    }

    private void CheckPunchInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _animator.SetTrigger("Punch");
        }
    }

    private void CheckIsGrounded()
    {
        _isGrounded = Physics.CheckSphere(_groundChecker.position, _groundCheckerRadius, _groundLayer);
        _animator.SetBool("IsGrounded", _isGrounded);
    }

    private void HandleJumpInput()
    {
        if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Move(Vector3 direction)
    {
        if (direction.magnitude >= 0.1)
        {
            float rotationAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationAngle, ref _rotationVelocity, _rotationTime);
            transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f);
            Vector3 movementDirection = Quaternion.Euler(0f, rotationAngle, 0f) * Vector3.forward;
            _rigidbody.AddForce(movementDirection * _speed * Time.deltaTime);
        }
        float velocity = GetNormalizedVelocity();
        _animator?.SetFloat("Velocity", velocity);
    }

    private float GetNormalizedVelocity()
    {
        float velocityX = Mathf.Abs(_rigidbody.velocity.x);
        float velocityZ = Mathf.Abs(_rigidbody.velocity.z);
        float normalizedVelocity = (velocityX >= velocityZ) ? velocityX : velocityZ;
        return normalizedVelocity;
    }

    private void StartSprint()
    {
        _speed = _sprintSpeed;
    }

    private void StopSprint()
    {
        _speed = _walkSpeed;
    }

    private void Jump()
    {
        Vector3 jumpDirection = Vector3.up;
        _rigidbody.AddForce(jumpDirection * _jumpSpeed * Time.deltaTime, ForceMode.Impulse);
    }
}
