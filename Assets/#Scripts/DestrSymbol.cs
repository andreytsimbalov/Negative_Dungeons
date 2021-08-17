using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestrSymbol : MonoBehaviour
{
    public GameObject postSymbol;

    public void DestrMe()
    {
        GameObject asd = Instantiate(postSymbol, transform.position, Quaternion.identity);//Quaternion.identity
        Destroy(asd, 2f);
        Destroy(gameObject);
    }
}
