using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    public float timerTotal = 10f;
    public float timer;

    public Slider slider;
    public LvlController lvlController;
    private bool restLvl = false;

    void Start()
    {
        timer = timerTotal;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = timer / timerTotal;
        timer -= Time.deltaTime;

        if (timer <= 0) RestartLvl();
    }

    public void RestartLvl()
    {
        if (restLvl) return;
        lvlController.RestartLvl();
        restLvl = true;
    }
    public void addTimer()
    {
        timer = timerTotal;
    }

}
