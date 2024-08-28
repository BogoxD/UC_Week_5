using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] float RotationSpeed = 5f;
    [SerializeField] float RotationMultiplier = 2f;
    public bool xAxis, yAxis, zAxis;
    private Vector3 axis;
    private void Start()
    {
        axis.x = 0;
        axis.y = 0;
        axis.z = 0;

        if (xAxis)
            axis.x = 1;
        if (yAxis)
            axis.y = 1;
        if (zAxis)
            axis.z = 1;

    }
    void Update()
    {
        transform.Rotate(axis * (RotationSpeed * RotationMultiplier) * Time.deltaTime);
    }
}
