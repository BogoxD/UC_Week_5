using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandRotation : MonoBehaviour
{
    public float RotationSpeed = 2f;
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        transform.Rotate(new Vector3(0, RotationSpeed * horizontal, 0) * Time.deltaTime);
    }
}
