using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class DoorSpawner : MonoBehaviour
{
    [SerializeField] float bigSpawnRange = 50f;
    [SerializeField] float smallSpawnRange = 20f;
    [SerializeField] float doorCheckRadius = 15f;

    [SerializeField] LayerMask layerMask;
    [SerializeField] GameObject doorPrefab;
    void SpawnDoor()
    {
        Vector3 point;
        if (RandomPointFurtherThan(transform.position, bigSpawnRange, smallSpawnRange, out point))
        {
            GameObject closestWall;
            CheckClosestWall(point, doorCheckRadius, out closestWall);
            Debug.DrawLine(closestWall.transform.position, closestWall.transform.position + Vector3.up * 10, Color.red, 20f);
            closestWall.GetComponent<WallManager>().EnableDoor();

            //Instantiate(doorPrefab, closestWall.transform.position+Vector3.left*-0.1f, closestWall.transform.rotation, closestWall.transform);
        }
    }

    void Start()
    {
        SpawnDoor();
    }

    void CheckClosestWall(Vector3 center, float radius, out GameObject closestWall)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius, layerMask);
        float maxDistance = 0f;
        Collider maxCollider = hitColliders[0];
        Debug.LogError(hitColliders.Count()+ " door spaces");
        foreach (var hitCollider in hitColliders)
        {
            var distance = Vector3.Distance(hitCollider.gameObject.transform.position, center);
            if (distance > maxDistance)
            {
                maxDistance = distance;
                maxCollider = hitCollider;
            }
        }
        closestWall = maxCollider.gameObject;
    }

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
    
    bool RandomPointFurtherThan(Vector3 center, float range, float minRange, out Vector3 result)
    {
        for (int i = 0; i < 1000; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                if(Vector3.Distance(center, hit.position) > minRange)
                {
                    result = hit.position;
                    return true;
                }
                
            }
        }
        result = Vector3.zero;
        return false;
    }
}
