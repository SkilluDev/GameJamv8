using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    LayerMask _layerMask;
    [SerializeField] GameObject playerTransform;

    void Awake()
    {
        _layerMask = LayerMask.GetMask("Player");
        Debug.Log(_layerMask.ToString());
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        Vector3 position = playerTransform.transform.position;
        Vector3 direction = (transform.position - position).normalized;
        
        if(Physics.Raycast(position, direction, out hit, Mathf.Infinity, _layerMask))
        {
            Debug.DrawRay(transform.position, direction * hit.distance, Color.yellow); 
            Debug.Log("Line of sight");
        }
        else
        {
            Debug.DrawRay(position, direction * 1000, Color.white);
        }
        
    }
}
