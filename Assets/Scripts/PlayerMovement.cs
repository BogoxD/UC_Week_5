using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float maxVelocity = 10f;
    [SerializeField] float maxAngularVelocity = 5f;
    [SerializeField] float airMultiplier = 1.5f;
    [SerializeField] LayerMask whatIsGround;

    [Header("References")]
    //player position without rotation in real time
    [SerializeField] Transform PlayerPositionEmptyObj;

    private Camera mainCam;
    private Rigidbody rb;
    private Vector3 respawnPosition = Vector3.zero;
    private Vector3 move;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCam = Camera.main;
    }

    void Update()
    {
        //check if is grounded
        GroundCheck();

        //move using physics
        OnMove();

        //clamp max speed
        ClampVelocity();
        ClamAngularVelocity();
    }
    private void OnMove()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        move = mainCam.transform.forward * moveSpeed * vertical + mainCam.transform.right * moveSpeed * horizontal;

        if (isGrounded)
            rb.AddForce(move.normalized);
        else
            rb.AddForce(move.normalized * airMultiplier);
    }
    private void ClampVelocity()
    {
        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
        }
    }
    private void ClamAngularVelocity()
    {
        if (rb.angularVelocity.magnitude > maxAngularVelocity)
        {
            rb.angularVelocity = Vector3.ClampMagnitude(rb.angularVelocity, maxAngularVelocity);
        }
    }
    private void GroundCheck()
    {
        if (Physics.Raycast(PlayerPositionEmptyObj.position, -Vector3.up, GetComponent<SphereCollider>().radius / 2 + 0.2f, whatIsGround))
            isGrounded = true;
        else
            isGrounded = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeadZone"))
        {
            transform.position = respawnPosition;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
