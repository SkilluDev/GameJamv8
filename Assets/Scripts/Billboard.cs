using UnityEngine;

public class Billboard : MonoBehaviour
{
   private Transform _cam;
    
    private void Start()
    {
        _cam = GameManager.Instance.cameraHolder;
        if (_cam is null) Debug.Log("Camera null");
    }

    void LateUpdate()
    {
        Vector3 targetPos = _cam.position;
        targetPos.y = transform.position.y;
        transform.LookAt(targetPos);
    }
}