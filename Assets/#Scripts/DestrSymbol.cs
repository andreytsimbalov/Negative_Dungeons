using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestrSymbol : MonoBehaviour
{
    public GameObject postSymbol;
    public bool canIBeDestroyed = true;
    public bool iChangeColor = false;
    public Sprite[] sps;
    private void Start()
    {
        transform.Find("Spr").GetComponent<SpriteRenderer>().sprite = sps[Random.Range(0, sps.Length)];
    }
    public void DestrMe()
    {
        if (!canIBeDestroyed) return;
        GameObject asd = Instantiate(postSymbol, transform.position, Quaternion.identity);//Quaternion.identity
        Destroy(asd, 2f);
        Destroy(gameObject);
    }


    public void StartDarness()
    {
        if (iChangeColor) return;
        iChangeColor = true;
        StartCoroutine(StartDarness_cor());
    }

    IEnumerator StartDarness_cor()
    {
        int len = 10 * Random.Range(1, 14);
        SpriteRenderer sr = transform.Find("Spr").GetComponent<SpriteRenderer>();
        for (int i = 0; i < len; i++)
        {
            //for (int j = 0; j < blackDisplays.Length; j++)
            //{
            //    blackDisplays[j].color = new Color(blackDisplays[j].color.r,
            //    blackDisplays[j].color.g,
            //    blackDisplays[j].color.b,
            //    Mathf.Lerp(0, 1, 1 - (float)(i + 1) / len));
            //}
            float con = Mathf.Lerp(0.2f, 1, 1 - (float)(i + 1) / len);
            sr.color = new Color(sr.color.r * con,
                sr.color.g * con,
                sr.color.b * con,
                1);

            yield return new WaitForSeconds(0.1f);
        }

    }
}
