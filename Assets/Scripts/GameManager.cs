using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private string timeTracker;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!DestroyBuggy.isDead)
        {
            timeTracker = Time.time.ToString("F2");
        }
        Debug.Log(timeTracker);
        Debug.Log(PlayerController.carSpeed.ToString("F0"));

    }

}
