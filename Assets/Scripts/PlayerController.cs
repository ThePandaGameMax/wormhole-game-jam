using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float carSpeed = 10;
    public float maxSpeed = 70;

    private Rigidbody rb;

    private Vector3 moveDir;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("ScaleSpeed", 10, 10);
    }

    // Update is called once per frame
    void Update()
    {
        // moveDir = new Vector3(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal")).normalized;
        moveDir = new Vector3(0, 0, Input.GetAxis("Horizontal")).normalized;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + (-transform.right) * carSpeed * Time.fixedDeltaTime);
        if (Input.GetAxis("Horizontal") != 0)
        {
            rb.MovePosition(rb.position + transform.TransformDirection(moveDir) * carSpeed * Time.fixedDeltaTime);

        }
    }
    void ScaleSpeed()
    {
        if (carSpeed < maxSpeed)
        {
            carSpeed = carSpeed * 1.5f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")

        {
            Debug.Log("GAME OVER");
        }

        if (other.tag == "Obstacle")
        {
            carSpeed = 15f;
        }
    }
}
