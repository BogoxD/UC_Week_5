using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] float sensitivity = 2f;
    float mouseX;

    void Update()
    {
        MouseXLook();
    }
    void MouseXLook()
    {
        mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);
    }
}
