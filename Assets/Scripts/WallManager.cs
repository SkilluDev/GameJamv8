using UnityEngine;

public class WallManager : MonoBehaviour
{
    [SerializeField] private GameObject door;
    public void EnableDoor()
    {
        door.SetActive(true);
    }
}
