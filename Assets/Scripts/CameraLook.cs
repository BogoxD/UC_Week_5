using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [SerializeField] Transform player;

    void Update()
    {
        LookTowards();
    }
    void LookTowards()
    {
        transform.forward = player.position - transform.position;
    }
}
