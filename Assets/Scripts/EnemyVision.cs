using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    LayerMask _playerLayer;
    [SerializeField] GameObject playerTransform;

    void Awake()
    {
        _playerLayer = LayerMask.GetMask("Player");
        Debug.Log(_playerLayer.ToString());
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        Vector3 position = playerTransform.transform.position;
        Vector3 direction = (position - transform.position).normalized;
        
        if(Physics.Raycast(transform.position, direction, out hit, Mathf.Infinity))
        {
            if ((_playerLayer & (1 << hit.transform.gameObject.layer)) != 0)
            {
                Debug.DrawRay(transform.position, direction * hit.distance, Color.yellow); 
            }
            else
            {
                Debug.DrawRay(transform.position, direction * 1000, Color.white);
            }

        }
        
    }
}
