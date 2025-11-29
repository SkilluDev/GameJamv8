using System.Collections;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private float _defaultSpeed;
    private Coroutine _slowCoroutine;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();

        if (_playerMovement is not null) _defaultSpeed = _playerMovement.movementSpeed;

        else Debug.LogError("PlayerCollect: PlayerMovement not found on this GameObject!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Collectibles")) return;

        if (other.CompareTag("Toxic Mushroom"))
        {
            if (_slowCoroutine is not null) StopCoroutine(_slowCoroutine);
            
            _slowCoroutine = StartCoroutine(ToxicSlowCoroutine(10f));
        }
        else if (other.CompareTag("Normal Mushroom")) Debug.Log("Normal Mushroom Collected");

        Destroy(other.gameObject);
    }

    private IEnumerator ToxicSlowCoroutine(float duration)
    {
        if (_playerMovement is null) yield break;

        _playerMovement.movementSpeed = _defaultSpeed * 0.5f;

        yield return new WaitForSeconds(duration);
        _playerMovement.movementSpeed = _defaultSpeed;
        _slowCoroutine = null;
    }
}