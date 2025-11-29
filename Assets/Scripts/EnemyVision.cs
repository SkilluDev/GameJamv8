using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    LayerMask _playerLayer;
    [SerializeField] private float speed;
    void Awake()
    {
        _playerLayer = LayerMask.GetMask("Player");
        Debug.Log(_playerLayer.ToString());
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            if ((_playerLayer & (1 << hit.transform.gameObject.layer)) != 0)
            {
                Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.yellow);
                transform.position += transform.forward * (speed * Time.fixedDeltaTime);
            }
            else
            {
                Debug.DrawRay(transform.position, transform.forward * 1000, Color.white);
            }

        }
        
    }
}
