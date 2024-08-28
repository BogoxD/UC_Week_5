using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]  float moveSpeed = 5f;

    private Camera mainCam;
    private Rigidbody rb;
    private Vector3 respawnPosition = Vector3.zero;
    private Vector3 move;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCam = Camera.main;
    }

    void Update()
    {
        OnMove();
    }
    private void OnMove()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        move = mainCam.transform.forward * moveSpeed * vertical + mainCam.transform.right * moveSpeed * horizontal;

        rb.AddForce(move.normalized);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("DeadZone"))
        {
            transform.position = respawnPosition;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
