using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpForce = 20f;
    [SerializeField] private bool _isGrounded = false;

    [SerializeField] private LayerMask _groundLayer;
    
    private Vector3 _moveVector;
    private Rigidbody _rigidBody;

    // Start is called before the first frame update
    void Start()
    {
         _rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Setting the input to the variables
        _moveVector.x = Input.GetAxisRaw("Horizontal");
        _moveVector.z = Input.GetAxisRaw("Vertical");

        // Raycast for checking if on ground.
        RaycastHit hit;
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, out hit, 0.55f, _groundLayer);
       
       // Jump code - can only jump if grounded
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rigidBody.velocity = Vector2.up * _jumpForce;
        }

        // Adding up the movement vectors
         _moveVector = new Vector3(_moveVector.x * _speed, _rigidBody.velocity.y, _moveVector.z * _speed);
    }

    // FixedUpdate is called 50 times per second
    void FixedUpdate() 
    {
        // Setting the movement
        _rigidBody.velocity = _moveVector;
    }
}