using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScr : MonoBehaviour
{
    string[] texts_death = new string[]
    { "Even mathematicians \n die at work... \n ...hmm, fun",
        "You couldn’t solve \n this example anyway",
        "auch",
        "Euclid, Gauss, Cauchy, Euler... \n it's a pity that no one \n will know about you like that"
    };

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.tag == "Player")
        {
            GameObject.Find("Interface").GetComponent<WLMessage>().EndLvl(false, texts_death[Random.Range(0, texts_death.Length)]);

            collision.GetComponent<PlayerController1>().Die(true);
        }
    }
}
