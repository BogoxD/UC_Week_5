using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    protected PlayerInteraction _player;
    protected Rigidbody _playerRigidbody;
    private void Awake()
    {
        _player = FindObjectOfType<PlayerInteraction>();
        if (_player)
            _playerRigidbody = _player.GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        //if colliding with player
        if (other.TryGetComponent<PlayerInteraction>(out PlayerInteraction pi))
            OnEnterTriggerExecute();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<PlayerInteraction>(out PlayerInteraction pi))
            OnStayTriggerExecute();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerInteraction>(out PlayerInteraction pi))
            OnExitTriggerExecute();
    }
    public abstract void OnEnterTriggerExecute();
    public abstract void OnStayTriggerExecute();
    public abstract void OnExitTriggerExecute();

}
