﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberBlock : MonoBehaviour
{
    // + - *

    public GameObject number;
    public GameObject operators;

    public Vector2 offsetInst = Vector2.right;
    public int oper = 0;
    private string[] oper_s = new string[] { "+", "-", "*", "=" };

    public int[] a = new int[3];
    public int[] res = new int[3];
    public string[] res_s = new string[3];

    private TimerBar timerBar;
    void Start()
    {
        timerBar = GameObject.Find("TimerBar").GetComponent<TimerBar>();
        GenerateEquation(-1, -1, 3);
        IntsNumbers();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GenerateEquation(-1, -1, 3);
            IntsNumbers();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            //delNumber(1, Random.Range(0, ););
        }
    }

    void IntsNumbers()
    {
        int iter = 0;
        for (int i = 0; i < res_s.Length; i++)
        {
            char[] charArr = res_s[i].ToCharArray();
            for (int j = 0; j < charArr.Length; j++)
            {
                GameObject num = Instantiate(number, transform);
                Vector2 tr = transform.position;
                num.transform.position = tr + offsetInst * iter;
                num.GetComponent<Number>().SetNumber(charArr[j].ToString(), i, j);


                iter++;
            }

            if (i == 0)
            {
                GameObject num = Instantiate(operators, transform);
                Vector2 tr = transform.position;
                num.transform.position = tr + offsetInst * iter;
                num.transform.Find("Canvas/Text").GetComponent<Text>().text = oper_s[oper];

                iter++;
            }

            if (i == 1)
            {
                GameObject num = Instantiate(operators, transform);
                Vector2 tr = transform.position;
                num.transform.position = tr + offsetInst * iter;
                num.transform.Find("Canvas/Text").GetComponent<Text>().text = oper_s[3];

                iter++;
            }
        }
    }

    public void DelNumbers()
    {
        foreach (Transform child in transform)
            child.GetComponent<DestrSymbol>().DestrMe();
    }

    public void GenerateEquation(int oper_loc = -1, int id = -1, int hard_lvl = 1)
    {
        id = id == -1 ? Random.Range(0, 3) : id;
        oper = oper_loc == -1 ? Random.Range(0, 3) : oper_loc;

        switch (oper)
        {
            case 0:
                a[0] = Random.Range(1, 10);
                a[1] = Random.Range(1, 10);
                a[2] = a[0] + a[1];
                break;
            case 1:
                a[1] = Random.Range(1, 10);
                a[2] = Random.Range(1, 10);
                a[0] = a[2] + a[1];
                break;
            case 2:
                a[0] = Random.Range(2, 10);
                a[1] = Random.Range(3, 10);
                a[2] = a[0] * a[1];
                break;
        }

        for (int i = 0; i < a.Length; i++)
        {
            res[i] = a[i];
        }

        for (int j = 0; j < hard_lvl; j++)
        {
            res[id] = addNumber(res[id]);
        }

        for (int i = 0; i < a.Length; i++)
        {
            res_s[i] = res[i].ToString();
        }

    }

    int addNumber(int x)
    {
        string s = x.ToString() + ' ';
        int len = s.Length;
        int id = Random.Range(0, len);
        int new_x = Random.Range(1, 10);
        string new_s = s.Substring(0, id) + new_x.ToString() + s.Substring(id, len - id);
        x = System.Convert.ToInt32(new_s);

        return x;
    }

    public void delNumber(int i, int sub_i)
    {
        bool del_error = false;

        char[] charArr = res_s[i].ToCharArray();
        charArr[sub_i] = ' ';
        res_s[i] = "";
        string res_temp_s = "";
        foreach (char ch in charArr)
        {
            res_s[i] += ch;
            if (ch != ' ') res_temp_s += ch;
        }

        if (res_temp_s == "") del_error = true;
        else
        {
            res[i] = System.Convert.ToInt32(res_temp_s);
            if (!checkEquation()) del_error = true;
        }


        if (del_error)
        {
            timerBar.lvlController.RestartLvl();
            print("equt ERROR");
            DelNumbers();
        }

        if (checkEquationFinal())
        {
            timerBar.addTimer();
            print("WIN");
            DelNumbers();
        }

    }

    bool checkEquation()
    {
        bool res_bool = true;

        for (int i = 0; i < a.Length; i++)
        {
            string res_str = res[i].ToString();
            if (!res_str.Contains(a[i].ToString())) res_bool = false;
        }

        return res_bool;
    }
    bool checkEquationFinal()
    {
        bool res_bool = true;

        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] != res[i]) res_bool = false;
        }

        return res_bool;
    }
}
