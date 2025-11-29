using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public UnityEvent onMouseClick;
    [SerializeField] private Transform cameraPosition;

    [SerializeField] private LayerMask enemyLayer;

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
            Debug.DrawRay(cameraPosition.position, cameraPosition.TransformDirection(Vector3.forward) * hit.distance, Color.red, 20f);
            Debug.Log("hittt" + hit.distance+"layer"+hit.transform.gameObject.layer);
            if((enemyLayer & (1 << hit.transform.gameObject.layer)) != 0)
            {
                Debug.Log("enemy");
            }
        }
    }
}
