using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    LayerMask _playerLayer;
    [SerializeField] private float speed;
    [SerializeField] float timeBetweenAttacks = 0.5f;
    private float _attackTimeCounter;
    [SerializeField] float damage;
    private PlayerHealth _playerHealth;

    private void Start()
    {
        _playerHealth = GameManager.Instance.playerHealth;
   }

    void Awake()
    {
        _playerLayer = LayerMask.GetMask("Player");
        Debug.Log(_playerLayer.ToString());
        _attackTimeCounter = timeBetweenAttacks;
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            if ((_playerLayer & (1 << hit.transform.gameObject.layer)) != 0)
            {
                Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.yellow);
                if (hit.distance >= 1f)
                    transform.position += transform.forward * (speed * Time.fixedDeltaTime);
                if (hit.distance <= 1f && _attackTimeCounter >= timeBetweenAttacks)
                {
                    _playerHealth.Damage(damage);
                    _attackTimeCounter = 0f;
                }
                _attackTimeCounter += Time.fixedDeltaTime;
            }
            else
            {
                Debug.DrawRay(transform.position, transform.forward * 1000, Color.white);
            }

        }
        
    }
}
