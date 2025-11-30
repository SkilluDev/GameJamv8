using System;
using Unity.Cinemachine;
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

    [SerializeField] private CinemachineImpulseSource cinemachineImpulseSource;
    private float timer = 0f;
    private float timePerStep = 0.25f;

    private float sineTimer = 0f;

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
            sineTimer += Time.deltaTime*Mathf.PI/timePerStep;

            if (timer >= timePerStep)
            {
                timer = 0f;
                Step();
            }

            _rb.AddForce(_moveDirection.normalized * (movementSpeed * sprintMultiplier) * 10f, ForceMode.Force);
        }
        else if(_moveDirection!=Vector3.zero)
        {
            timer += Time.deltaTime / 2;
            sineTimer += (Time.deltaTime/2)*Mathf.PI/timePerStep;

            if (timer >= timePerStep)
            {
                timer = 0f;
                Step();
            }

            _rb.AddForce(_moveDirection.normalized * movementSpeed * 10f, ForceMode.Force);
        }
    }

    private void Step()
    {
        stepSound.Play(audioSource);
        float currentSine = Mathf.Sin(sineTimer);
        Debug.Log("sine=" + currentSine);
        Vector3 bounce;
        bounce = new Vector3(currentSine/3, -0.1f, 0);
        cinemachineImpulseSource.GenerateImpulse(bounce);
    }
}