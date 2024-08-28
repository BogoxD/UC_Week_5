using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPositionTarget : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    void Update()
    {
        SetPosition();
    }
    private void SetPosition()
    {
        transform.position = target.position - offset;
    }
}
