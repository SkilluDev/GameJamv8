using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Collectibles")) return;
        if (other.gameObject.tag == "Toxic Mushroom")
        {
            Debug.Log("Toxic Mushroom Collected");
        }

        else if (other.gameObject.tag == "Normal Mushroom")
        {
            Debug.Log("Normal Mushroom Collected");
        }
        Destroy(other.gameObject);
    }
}