using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;
    private Vector3 move;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        OnMove();
    }
    private void OnMove()
    {
        float vertical = Input.GetAxis("Vertical");

        move = Camera.main.transform.forward * moveSpeed * vertical;

        rb.AddForce(move.normalized);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("DeadZone"))
        {
            transform.position = Vector3.zero;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
