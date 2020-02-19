using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private DestroyBuggy destroyBuggy;

    public AudioSource deathAudio;
    public AudioSource rockHitAudio;
    public AudioSource engineBoostAudio;

    private CinemachineVirtualCamera vCam;
    public float carSpeed = 10;
    public float maxSpeed = 70;

    private Rigidbody rb;

    private Vector3 moveDir;
    // Start is called before the first frame update
    private void Awake()
    {
        destroyBuggy = GameObject.Find("Dune Buggy4").GetComponent<DestroyBuggy>();
        vCam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
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
            engineBoostAudio.Play();
            carSpeed = carSpeed * 1.5f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")

        {
            destroyBuggy.DestroyCar();
            vCam.LookAt = null;
            vCam.Follow = null;
            deathAudio.Play();
        }

        if (other.tag == "Obstacle")
        {
            carSpeed = 15f;
            rockHitAudio.Play();
        }
    }
}
