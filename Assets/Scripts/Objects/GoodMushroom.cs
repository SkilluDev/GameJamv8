using UnityEngine;

public class MushroomPowerUp : MonoBehaviour
{
  [SerializeField] private readonly float timeBonus = 10f; 

  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Player"))
    {
      CollectMushroom();
    }
  }
  private void CollectMushroom()
  {
    GameManager.Instance?.AddMoreTime(timeBonus);

    Destroy(gameObject);
  }
}