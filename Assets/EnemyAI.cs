using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float maxDistance = 5f;

    Transform player;
    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        
    }
    void Update()
    {
        MoveTowardsTarget(player);
    }
    private void MoveTowardsTarget(Transform target)
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position, maxDistance * Time.deltaTime);
    }
}
