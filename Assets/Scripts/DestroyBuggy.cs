using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBuggy : MonoBehaviour
{
    public GameObject destroyedVersion;
    public static bool isDead;

    public void DestroyCar()
    {
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        Destroy(this.gameObject);
        isDead = true;
    }
}
