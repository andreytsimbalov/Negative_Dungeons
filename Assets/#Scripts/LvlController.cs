using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LvlController : MonoBehaviour
{
    public int set_now_lvl = 0;
    public float start_timer = 2f;
    public float restart_timer = 5f;
    public Image blackDisplay;
    void Start()
    {
        blackDisplay.color = new Color(blackDisplay.color.r,
                blackDisplay.color.g,
                blackDisplay.color.b,
                1);

        set_now_lvl = PlayerPrefs.GetInt("NowLvl");
        print(set_now_lvl);
        print(SceneManager.GetActiveScene().buildIndex);
        StartScene();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            FinishScene();
        }


        if (Input.GetKeyDown(KeyCode.T))
        {
            NextScene();
        }

        //if (Input.GetKeyDown(KeyCode.Tab))
        //{
        //    //pause_canv.SetActive(!pause_canv.activeSelf);    
        //}

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            NextScene(0);
        }

        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    PlayerPrefs.SetInt("NowLvl", SceneManager.GetActiveScene().buildIndex);
        //}

        //if (Input.GetKeyDown(KeyCode.Y))
        //{
        //    PlayerPrefs.SetInt("NowLvl", 0);
        //}
    }

    public void NextScene(int ns= -1)
    {
        StartCoroutine(NextScene_cor(ns));
    }

    public void StartScene()
    {
        PlayerPrefs.SetInt("NowLvl", SceneManager.GetActiveScene().buildIndex);
        StartCoroutine(StartScene_cor());
    }

    public void FinishScene()
    {
        StartCoroutine(FinishScene_cor());
    }

    IEnumerator StartScene_cor()
    {
        int len = 10 * (int)start_timer;
        for (int i = 0; i < len; i++)
        {
            blackDisplay.color = new Color(blackDisplay.color.r,
                blackDisplay.color.g,
                blackDisplay.color.b,
                Mathf.Lerp(0, 1, 1 - (float)(i + 1) / len));

            yield return new WaitForSeconds(1 / 10);
        }

    }

    IEnumerator FinishScene_cor()
    {
        //yield return new WaitForSeconds(restart_timer);

        int len = 10 * (int)start_timer;
        for (int i = 0; i < len; i++)
        {
            blackDisplay.color = new Color(blackDisplay.color.r,
                blackDisplay.color.g,
                blackDisplay.color.b,
                Mathf.Lerp(1, 0, 1 - (float)(i + 1) / len));

            yield return new WaitForSeconds(1 / 10);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    IEnumerator NextScene_cor(int ns = -1)
    {
        //yield return new WaitForSeconds(restart_timer);

        int len = 10 * (int)start_timer;
        for (int i = 0; i < len; i++)
        {
            blackDisplay.color = new Color(blackDisplay.color.r,
                blackDisplay.color.g,
                blackDisplay.color.b,
                Mathf.Lerp(1, 0, 1 - (float)(i + 1) / len));

            yield return new WaitForSeconds(1 / 10);
        }

        ns = ns == -1 ? SceneManager.GetActiveScene().buildIndex + 1  : ns;

        if (ns >= SceneManager.sceneCountInBuildSettings)
            ns = 0;
        SceneManager.LoadScene(ns);
    }

}
