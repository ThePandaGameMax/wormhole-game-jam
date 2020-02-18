using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float wormSpeed = 5;
    private Transform car;
    public GameObject worm;
    private Vector3 startPos;
    public static float wormRange = 150;

    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.Find("Car").GetComponent<Transform>();
        startPos = worm.transform.position;
    }

    void FixedUpdate()
    {
        float distance = Vector3.Distance(worm.transform.position, car.position);
        if (distance < wormRange)
        {
            Vector3 direction = (car.position - transform.position);
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z));
            transform.rotation = lookRotation;
            worm.transform.position += worm.transform.forward * wormSpeed * Time.fixedDeltaTime;
        }
    }

}
