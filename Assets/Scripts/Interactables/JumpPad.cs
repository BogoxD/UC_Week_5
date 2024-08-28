using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : InteractableObject
{
    [SerializeField] float JumpForce = 5f;
    public override void OnEnterTriggerExecute()
    {
        _playerRigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
    }

    public override void OnExitTriggerExecute()
    {
        
    }

    public override void OnStayTriggerExecute()
    {

    }
}
