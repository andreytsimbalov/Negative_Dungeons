using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WLMessage : MonoBehaviour
{
    public TMP_Text text_not;
    public TMP_Text wl_mess;
    public TMP_Text rt_mess;
    public TimerBar timerBar;
    public PlayerController1 pc;

    bool already_activated = false;
    public AudioSource winSound;
    public AudioSource loseSound;
    //audioSource.Play();

    void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController1>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndLvl(bool win_flag, string mess)
    {
        if (already_activated) return;
        already_activated = true;

        wl_mess.text = "\n LOSE";
        if (win_flag)
        {
            winSound.Play();
            wl_mess.text = "\n WIN";
        }
        else
        {
            loseSound.Play();
        }

        rt_mess.text = "restart level - R\n next level - T";

        text_not.text = mess;

        timerBar.stopIt = true;

        pc.Die();
    }

}
