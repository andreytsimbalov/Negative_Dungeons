﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Number : MonoBehaviour
{
    public NumberBlock numberBlock;
    public Text text;
    public string val;
    public int id;
    public int sub_id;


    private void Start()
    {
        numberBlock = GetComponentInParent<NumberBlock>();
    }

    public void SetNumber(string v,int i,int sub_i)
    {
        val = v;
        text.text = val;
        id = i;
        sub_id = sub_i;
    }

    public void DestrMe()
    {
        numberBlock.delNumber(id, sub_id);
        //Destroy(gameObject, 0.01f);
        Destroy(gameObject);
    }
}
