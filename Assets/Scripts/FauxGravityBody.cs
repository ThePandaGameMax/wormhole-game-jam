using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauxGravityBody : MonoBehaviour
{

    public FauxGravityAttractor attractor;
    private Transform carTransform;
    // Start is called before the first frame update

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.useGravity = false;

        carTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        attractor.Attract(carTransform);
    }
}
