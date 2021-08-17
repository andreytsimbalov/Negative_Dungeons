using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlController : MonoBehaviour
{
    public int set_now_lvl = 0;
    public float start_timer = 2f;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            FinishScene();
        }

        //if (Input.GetKeyDown(KeyCode.Tab))
        //{
        //    //pause_canv.SetActive(!pause_canv.activeSelf);    
        //}

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerPrefs.SetInt("NowLvl", set_now_lvl);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            PlayerPrefs.SetInt("NowLvl", 0);
        }

    }
    public void RestartLvl()
    {
        print("Restart LvL");
    }


    public void StartScene()
    {
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
            //for (int j = 0; j < blackDisplays.Length; j++)
            //{
            //    blackDisplays[j].color = new Color(blackDisplays[j].color.r,
            //    blackDisplays[j].color.g,
            //    blackDisplays[j].color.b,
            //    Mathf.Lerp(0, 1, 1 - (float)(i + 1) / len));
            //}


            yield return new WaitForSeconds(1 / 10);
        }

    }

    IEnumerator FinishScene_cor()
    {
        int len = 10 * (int)start_timer;
        for (int i = 0; i < len; i++)
        {
            //for (int j = 0; j < blackDisplays.Length; j++)
            //{
            //    blackDisplays[j].color = new Color(blackDisplays[j].color.r,
            //    blackDisplays[j].color.g,
            //    blackDisplays[j].color.b,
            //    Mathf.Lerp(0, 1, (float)i / len));
            //}
            yield return new WaitForSeconds(1 / 10);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

}
