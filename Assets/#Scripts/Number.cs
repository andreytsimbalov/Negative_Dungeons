using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Number : MonoBehaviour
{
    public NumberBlock numberBlock;
    //public Text text;
    public TMP_Text text;
    public string val;
    public int id;
    public int sub_id;
    private DestrSymbol destrSymbol;

    private void Start()
    {
        //text = transform.Find("Canvas/Text").GetComponent<TMP_Text>();
        destrSymbol = GetComponent<DestrSymbol>();
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
        if (!destrSymbol.canIBeDestroyed) return;

        numberBlock.delNumber(id, sub_id);
        destrSymbol.DestrMe();
    }

}
