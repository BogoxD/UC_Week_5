using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCup : InteractableObject
{
    public override void OnEnterTriggerExecute()
    {
        gameObject.SetActive(false);
        GameManager.instance.CheckCrowns();
    }

    public override void OnExitTriggerExecute()
    {
    }

    public override void OnStayTriggerExecute()
    {
    }
    private void OnDisable()
    {
    }
}
