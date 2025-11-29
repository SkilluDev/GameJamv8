using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class SpawnEntities : MonoBehaviour
{
    [SerializeField] float spawnRange = 50.0f;
    [SerializeField] int enemyCount = 30;
    [SerializeField] int mushroomCount = 10;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject mushroomPrefab;

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 1000; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }
    void Start()
    {
        for(int i = 0; i < enemyCount; i++)
        {
            Vector3 point;
            if (RandomPoint(transform.position, spawnRange, out point))
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                Instantiate(enemyPrefab, point+Vector3.up*1.68f, Quaternion.identity);
            }
        }

        for(int i = 0; i < mushroomCount; i++)
        {
            Vector3 point;
            if (RandomPoint(transform.position, spawnRange, out point))
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                Instantiate(mushroomPrefab, point+Vector3.up*1.68f, Quaternion.identity);
            }
        }
        
    }


}
