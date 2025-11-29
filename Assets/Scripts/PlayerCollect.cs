using System.Collections;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private GameManager _gameManager;
    private float _defaultSpeed;
    private Coroutine _slowCoroutine;

    private void Awake()
    {
        _gameManager  = GameObject.Find("GameManager").GetComponent<GameManager>();
        _playerMovement = GetComponent<PlayerMovement>();

        if (_playerMovement is not null) _defaultSpeed = _playerMovement.movementSpeed;

        else Debug.LogError("PlayerCollect: PlayerMovement not found on this GameObject!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Collectibles")) return;

        if (other.CompareTag("Toxic Mushrooms"))
        {
            
            if (_slowCoroutine is not null) StopCoroutine(_slowCoroutine);
            
            _slowCoroutine = StartCoroutine(ToxicSlowCoroutine(10f));
        }
        else if (other.CompareTag("Normal Mushrooms"))
        { 
            _gameManager.AddMoreTime(30f);
        }

        Destroy(other.gameObject);
    }

    private IEnumerator ToxicSlowCoroutine(float duration)
    {
        if (_playerMovement is null) yield break;

        _playerMovement.movementSpeed = _defaultSpeed * 0.5f;
        _playerMovement.canSprint = false;
        yield return new WaitForSeconds(duration);
        _playerMovement.movementSpeed = _defaultSpeed;
        _playerMovement.canSprint = true;
        _slowCoroutine = null;
    }
}