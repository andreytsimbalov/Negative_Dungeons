using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public PlayerController1 playerController;
    public Animator anim;

    public float Yvel_koeff = 0.1f;
    public bool death = false;
    private bool readyForAttack = true;

    private void Start()
    {
        playerController = GetComponent<PlayerController1>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (death) anim.SetBool("Death", true);

        anim.SetBool("Xmove", playerController.moveX != 0);

        int Yvector = 0;
        if (Mathf.Abs(playerController.nowYVelocity)> Yvel_koeff)
        {
            Yvector = playerController.nowYVelocity > 0 ? 1 : -1;
        }
        anim.SetInteger("Yvector", Yvector);
    }

    private void LateUpdate()
    {

        anim.SetBool("DoubleJump", !playerController.doubleJump && playerController.lestJump);//!playerController.doubleJump && 

    }
}
