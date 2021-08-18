using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumBlocksManager : MonoBehaviour
{
    //public int nextSceneId = -1;
    public int numberBlocksMax = 0;
    public int numberBlocksCounter = 0;
    public LvlController lvlController;

    public TMP_Text text_not;

    string[] texts_win = new string[]
    { "Cool! You are wonderful! \n Nerd",
        "Well, in the next lesson \n we will learn how \n to take triple integrals",
        "Couldn't you solve it faster?",
        "Nice fingerstyle",
        "Man, you do my eight year old \n sister's homework"
    };

    public void IterNumberBlocksCounter()
    {
        numberBlocksCounter++;
        if(numberBlocksCounter >= numberBlocksMax)
        {
            text_not.text = texts_win[Random.Range(0, texts_win.Length)];
            PlayerController1 plc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController1>();
            plc.canIDeath = false;
            plc.timerBar.stopIt = true;
            //lvlController.NextScene();
        }
    }

}
