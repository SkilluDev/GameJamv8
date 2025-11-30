using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool canSprint = true;
    private bool _isSprinting;
    public float sprintMultiplier = 1.5f;
    public float movementSpeed;
    public Transform orientation;
    private float _horizontalInput;
    private float _verticalInput;
    private Vector3 _moveDirection;
    [SerializeField] private RandomSound stepSound;
    [SerializeField] private AudioSource audioSource;
    private float timer = 0f;
    private float timePerStep = 0.25f;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
    }

    private void Update()
    {
        MyInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        _isSprinting = Input.GetKey(KeyCode.LeftShift);
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        _moveDirection = _horizontalInput * orientation.right + _verticalInput * orientation.forward;
        if (_isSprinting && canSprint)
        {
            timer += Time.deltaTime;
            if (timer >= timePerStep)
            {
                timer = 0f;
                stepSound.Play(audioSource);
            }

            _rb.AddForce(_moveDirection.normalized * (movementSpeed * sprintMultiplier) * 10f, ForceMode.Force);
        }
        else
        {
            timer += Time.deltaTime / 2;
            if (timer >= timePerStep)
            {
                timer = 0f;
                stepSound.Play(audioSource);
            }

            _rb.AddForce(_moveDirection.normalized * movementSpeed * 10f, ForceMode.Force);
        }
    }
}