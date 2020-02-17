using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauxGravityAttractor : MonoBehaviour
{
    public float gravity = -10f;

    public void Attract(Transform carBody)
    {
        Vector3 gravityUp = (carBody.position - transform.position).normalized;
        Vector3 bodyUp = carBody.up;

        carBody.GetComponent<Rigidbody>().AddForce(gravityUp * gravity);

        Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * carBody.rotation;
        carBody.rotation = Quaternion.Slerp(carBody.rotation, targetRotation, 50 * Time.deltaTime);
    }
}
