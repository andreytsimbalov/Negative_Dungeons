using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerBar : MonoBehaviour
{
    public float timerTotal = 10f;
    public float timer;

    public TMP_Text text_not;
    public Slider slider;
    public LvlController lvlController;
    private bool restLvl = false;
    public bool stopIt = false;

    string[] texts_time_lose = new string[]
    { "Time flies when \n you're having fun",
        "It's not time yet",
        "You are late",
        "Time is money \n and you are bankrupt"
    };


    void Start()
    {
        timer = timerTotal;
    }

    // Update is called once per frame
    void Update()
    {
        if (stopIt) return;
        slider.value = timer / timerTotal;
        timer -= Time.deltaTime;

        if (timer <= 0) RestartLvl();
    }

    public void RestartLvl()
    {
        if (restLvl) return;
        //lvlController.FinishScene();

        GameObject.Find("Interface").GetComponent<WLMessage>().EndLvl(false, texts_time_lose[Random.Range(0, texts_time_lose.Length)]);

        //text_not.text = texts_time_lose[Random.Range(0, texts_time_lose.Length)];

        //GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController1>().Die();

        restLvl = true;
    }
    public void addTimer()
    {
        timer = timerTotal;
    }

}
