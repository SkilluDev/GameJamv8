using System;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    private float _rotationX;

    public Transform orientation;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensX;
        _rotationX += Mathf.Clamp(mouseX, -90f, 90f);
        
        transform.rotation = Quaternion.Euler(0, _rotationX, 0);
        orientation.rotation = Quaternion.Euler(0, _rotationX, 0);
    }
}
