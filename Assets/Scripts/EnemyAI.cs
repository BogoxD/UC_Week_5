using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float speed = 5f;

    private Rigidbody enemyRb;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        enemyRb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        MoveTowardsTarget(player);
    }
    private void MoveTowardsTarget(Transform target)
    {
        Vector3 moveDirection = (target.position - transform.position).normalized;
        enemyRb.AddForce(moveDirection * speed, ForceMode.Force);
    }
}
