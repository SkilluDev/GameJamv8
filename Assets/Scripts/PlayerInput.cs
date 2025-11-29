using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public UnityEvent onMouseClick;
    [SerializeField] private Transform cameraPosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            onMouseClick.Invoke();
        }
    }

    public void Shoot()
    {
        RaycastHit hit;
        Debug.Log("test");

        if(Physics.Raycast(cameraPosition.position, cameraPosition.TransformDirection(Vector3.forward),  out hit, 100f))
        {
            Debug.DrawRay(cameraPosition.position, cameraPosition.TransformDirection(Vector3.forward) * 100f, Color.red);
            Debug.Log("hittt"+hit.distance);
        }
    }
}
