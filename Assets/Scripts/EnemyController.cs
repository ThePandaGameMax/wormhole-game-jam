using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 10f;
    public float objectTooFar = 20f;
    public Transform car;
    public NavMeshAgent worm;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        float distance = Vector3.Distance(car.position, transform.position);

        if (distance <= lookRadius)
        {
            Facecar();
            worm.SetDestination(car.position);

        }
    }

    void Facecar()
    {
        Vector3 direction = (car.position - transform.position);
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = lookRotation;
    }
}
