using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBulSpawner : MonoBehaviour
{
    public float startTimer = 10f;
    public float timer;

    public GameObject bullet;
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = startTimer;
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}
