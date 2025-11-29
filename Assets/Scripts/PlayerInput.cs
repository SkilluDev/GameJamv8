using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public UnityEvent onMouseClick;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            onMouseClick.Invoke();
        }
    }
}
