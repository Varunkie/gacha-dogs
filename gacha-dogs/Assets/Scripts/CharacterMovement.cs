using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    #region Settings
    public float movementSpeed = 9.5f;
    public float jumpBoostSpeed = 25f;

    public float groundRaycastDistance = 1f;

    [SerializeField, ReadOnly] private bool _ground;
    #endregion

    private readonly string HORIZONTAL_AXIS = "Horizontal";
    private readonly string JUMP_BUTTON = "Jump";

    private Rigidbody2D _rigidbody;
    private Vector2 _currentVelocity;

    private bool _jumpButtonDown;
    private float _horizontal;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        Physics2D.queriesStartInColliders = false;
    }

    private void Update()
    {
        Inputs();
    }

    private void FixedUpdate()
    {
        State();
        Velocity();
    }

    private void Inputs()
    {
        _horizontal = Input.GetAxisRaw(HORIZONTAL_AXIS);
        _jumpButtonDown |= Input.GetButtonDown(JUMP_BUTTON);
    }

    private void Velocity()
    {
        // Get velocity
        _currentVelocity = _rigidbody.velocity;

        // Physics
        Horizontal();
        Vertical();

        // Set velocity
        _rigidbody.velocity = _currentVelocity;
    }

    #region Calculate Methods
    private void Horizontal()
    {
        float speed = _horizontal * movementSpeed;
        _currentVelocity.x = speed;
    }

    private void Vertical()
    {
        if (_jumpButtonDown && _ground)
        {
            _currentVelocity.y = jumpBoostSpeed; 
        }
        _jumpButtonDown = false;
    }
    #endregion

    private void State()
    {
        Below();
    }

    #region Below Methods
    private void Below()
    {
        var raycast = Physics2D.Raycast(transform.position, Vector2.down, groundRaycastDistance);
        _ground = _rigidbody.velocity.y <= 0f && raycast.collider != null;
    }
    #endregion

}
