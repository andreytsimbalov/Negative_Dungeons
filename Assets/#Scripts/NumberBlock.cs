using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NumberBlock : MonoBehaviour
{
    public int oper_loc = -1;
    public int id = -1;
    public int hard_lvl = 1;


    public GameObject number;
    public GameObject operators;

    public bool invertInts = false;

    public Vector2 offsetInst = Vector2.right;
    public int oper = 0;
    private string[] oper_s = new string[] { "+", "-", "*", "=" };

    public int[] a = new int[3];
    public int[] res = new int[3];
    public string[] res_s = new string[3];

    private TimerBar timerBar;

    private NumBlocksManager numBlocksManager;


    string[] texts_error_math = new string[]
    { "Not mathematical",
        "e^(i*PI) + 1 = 0 \n at least remember this",
        "F",
        "An infinite number of \n mathematicians walk into a bar... \n ...but without you"
    };


    void Start()
    {
        numBlocksManager = GameObject.Find("NumBlocksManager").GetComponent<NumBlocksManager>();
        timerBar = GameObject.Find("TimerBar").GetComponent<TimerBar>();
        GenerateEquation(oper_loc, id, hard_lvl);
        IntsNumbers();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Tab))
    //    {
    //        GenerateEquation(-1, -1, 3);
    //        IntsNumbers();
    //    }

    //    if (Input.GetKeyDown(KeyCode.T))
    //    {
    //        delNumber(1, Random.Range(0, ););
    //    }
    //}

    void IntsNumbers()
    {
        if (invertInts)
        {
            int iter = 0;
            for (int i = res_s.Length - 1; i >= 0; i--)
            {
                char[] charArr = res_s[i].ToCharArray();

                if (i == 0)
                {
                    GameObject num = Instantiate(operators, transform);
                    Vector2 tr = transform.position;
                    num.transform.position = tr + offsetInst * iter;
                    num.transform.Find("Canvas/Text").GetComponent<TMP_Text>().text = oper_s[oper];

                    iter++;
                }

                if (i == 1)
                {
                    GameObject num = Instantiate(operators, transform);
                    Vector2 tr = transform.position;
                    num.transform.position = tr + offsetInst * iter;
                    num.transform.Find("Canvas/Text").GetComponent<TMP_Text>().text = oper_s[3];

                    iter++;
                }

                for (int j = charArr.Length-1; j >=0 ; j--)
                {
                    GameObject num = Instantiate(number, transform);
                    Vector2 tr = transform.position;
                    num.transform.position = tr + offsetInst * iter;
                    num.GetComponent<Number>().SetNumber(charArr[j].ToString(), i, j);


                    iter++;
                }


            }
        }
        else
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
                    num.transform.Find("Canvas/Text").GetComponent<TMP_Text>().text = oper_s[oper];

                    iter++;
                }

                if (i == 1)
                {
                    GameObject num = Instantiate(operators, transform);
                    Vector2 tr = transform.position;
                    num.transform.position = tr + offsetInst * iter;
                    num.transform.Find("Canvas/Text").GetComponent<TMP_Text>().text = oper_s[3];

                    iter++;
                }
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

            foreach (Transform child in transform)
            {
                child.GetComponent<DestrSymbol>().canIBeDestroyed = false;
                child.GetComponent<DestrSymbol>().StartDarness();
            }

            GameObject.Find("Interface/TextNotificaton").GetComponent<TMP_Text>().text = texts_error_math[Random.Range(0, texts_error_math.Length)];
            timerBar.stopIt = true;

            //timerBar.lvlController.FinishScene();
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController1>().Die();
            print("equt ERROR");
            //DelNumbers();
        }

        if (checkEquationFinal())
        {
            numBlocksManager.IterNumberBlocksCounter();
            timerBar.addTimer();
            print("WIN");
            CascadeDeletion();
            //DelNumbers();
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

    public void CascadeDeletion()
    {
        StartCoroutine(CascadeDeletion_cor());
    }

    IEnumerator CascadeDeletion_cor()
    {
        while (transform.childCount != 0)
        {
            transform.GetChild(0).GetComponent<DestrSymbol>().DestrMe();
            yield return new WaitForSeconds(0.05f);
        }

        //foreach (Transform child in transform)
        //{
        //    child.GetComponent<DestrSymbol>().DestrMe();
        //    yield return new WaitForSeconds(0.02f);
        //}
    }
}
