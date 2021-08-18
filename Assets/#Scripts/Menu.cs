using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public TMP_Text nowLvl;
    public GameObject lvlButton;
    public Transform spawn;
    private int sceneCount;
    public int sceneDiv = 5;
    public float offset = 1.2f;

    int now_lvl = 0;


    void Start()
    {
        sceneCount = SceneManager.sceneCountInBuildSettings;
        chooseLvl(PlayerPrefs.GetInt("NowLvl"));
        InstButts();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitApp();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            startLvl();
        }
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    void chooseLvl(int lvl)
    {
        now_lvl = lvl;
        lvl--;
        nowLvl.text = "Level " + lvl.ToString();
    }

    public void startLvl()
    {
        SceneManager.LoadScene(now_lvl);
    }

    void InstButts()
    {
        int iterx = -1;
        int itery = -1;
        sceneCount = 20;
        for (int i = 0; i < sceneCount-2; i++)
        {
            iterx++;
            if (i % sceneDiv == 0)
            {
                iterx = 0;
                itery++;
            }

            Vector2 new_pos = spawn.position;
            new_pos += new Vector2(offset * iterx, - offset * itery);
            print(new_pos);
            Button but = Instantiate(lvlButton, new_pos, spawn.rotation, spawn).GetComponentInChildren<Button>();
            but.GetComponentInChildren<TMP_Text>().text = (i+1).ToString();
            int new_i = i + 2;
            but.onClick.AddListener(() => chooseLvl(new_i));// 
        }

        //lvlButton.onClick.AddListener(() => chooseLvl(iter+2)); 
    }
}
