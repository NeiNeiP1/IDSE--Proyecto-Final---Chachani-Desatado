using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class wandering : MonoBehaviour
{
    public float wanderRadius = 50.0f;
    public float wanderSpeed = 10.0f;
    private Vector3 wanderTarget;

    void Start()
    {
        GetNewWanderTarget();
    }

    void Update()
    {
        Vector3 direction = (wanderTarget - transform.position).normalized;
        transform.Translate(direction * wanderSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, wanderTarget) < 0.5f)
        {
            GetNewWanderTarget();
        }
    }

    void GetNewWanderTarget()
    {
        wanderTarget = Random.insideUnitSphere * wanderRadius;
        wanderTarget += transform.position;
        wanderTarget.y = transform.position.y;
    }
}
