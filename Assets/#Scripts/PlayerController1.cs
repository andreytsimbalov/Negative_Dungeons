using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController1 : MonoBehaviour
{

    public float forse_x = 15f;
    public float max_speed_x = 10f;
    public float jumpForse = 20f;
    private Rigidbody2D rb;
    public bool faceRight = true;
    public bool isGrounded;
    public Transform groundCheck;
    public float chackRadius = 0.1f;
    public LayerMask whatIsGround;

    private bool iAmDeshing = false;
    private bool canDesh = true;
    public float dashForse = 20f;
    public float deshTime = 0.1f;
    private float deshTime_now = 0f;

    //public LvlController lvlController;

    public WLMessage wlmess;
    public TMP_Text text_not;
    public TimerBar timerBar;

    public CamMove camMove;
    private float shackCamTimer = 0.1f;

    public float nowXVelocity = 0f;
    public float nowYVelocity = 0f;
    public float moveX = 0f;

    public bool lestJump = false;
    public bool doubleJump = true;
    public bool lestDesh = false;

    public bool death = false;
    public bool canIDeath = true;

    
    void Start()
    {
        timerBar = GameObject.Find("TimerBar").GetComponent<TimerBar>();
        float newGroundCheckXPos = GetComponent<BoxCollider2D>().offset.x;
        groundCheck.localPosition += new Vector3(newGroundCheckXPos, 0, 0);
        rb = GetComponent<Rigidbody2D>();
        chackRadius = GetComponent<BoxCollider2D>().size.x * 0.9f * 0.5f;
    }

    private void Update()
    {
        // 0020-007F,0400-04FF
        if (death) moveX = 0;
        if (death) return;
        // чтение перемещения
        moveX = Input.GetAxisRaw("Horizontal");
        // чтение прыжков
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (isGrounded == true)
            {
                lestJump = true;


            }
            else
            if (doubleJump)
            {
                lestJump = true;
                doubleJump = false;
            }

            //float timejump = 0.05f;
        }
        // чтение рывка
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDesh)
        {
            lestDesh = true;
            //float dashVecX = faceRight ? 1 : -1;
            //rb.velocity = new Vector2(dashVecX * dashForse, 0);
        }

        nowXVelocity = rb.velocity.x;
        nowYVelocity = rb.velocity.y;
    }

    void FixedUpdate()
    {

        // Деш в сторону
        if (lestDesh)
        {
            lestDesh = false;
            canDesh = false;
            iAmDeshing = true;
            deshTime_now = deshTime;
            //camMove.ShackCamera();
        }

        if (iAmDeshing)
        {
            deshTime_now -= Time.fixedDeltaTime;
            if (deshTime_now >= 0)
            {
                float dashVecX = faceRight ? 1 : -1;
                rb.velocity = new Vector2(dashVecX * dashForse, 0);
                return;
            }
            else
            {
                iAmDeshing = false;
                StopMoveAtMoment();

            }
        }


        isGrounded = Physics2D.OverlapCircle(groundCheck.position, chackRadius, whatIsGround);
        if (isGrounded)
        {
            doubleJump = true;
            canDesh = true;
            if (rb.velocity.y < -8f)
            {
                // сильное приземление
                //print(rb.velocity.y);
                camMove.ShackCamera(4, 0.1f, 0.02f);
            }

        }

        float fly_range = 1f;
        if (!isGrounded)
            fly_range = 0.3f;//коэффицент движения в полёте
        rb.AddForce(new Vector2(moveX, 0).normalized * forse_x * fly_range * Time.fixedDeltaTime, ForceMode2D.Impulse);


        if (rb.velocity.x < -max_speed_x)
            rb.velocity = new Vector2(-max_speed_x, rb.velocity.y);
        if (rb.velocity.x > max_speed_x)
            rb.velocity = new Vector2(max_speed_x, rb.velocity.y);

        //торможение на земле
        if (((moveX == 0) || (moveX * rb.velocity.x < 0)) && isGrounded && (Mathf.Abs(rb.velocity.x) > 0.1f))
        {
            rb.velocity = new Vector2(rb.velocity.x * 3 / 4, rb.velocity.y);
        }
        //торможение в воздухе
        if (((moveX == 0) || (moveX * rb.velocity.x < 0)) && !isGrounded && (Mathf.Abs(rb.velocity.x) > 0.1f))
        {
            rb.velocity = new Vector2(rb.velocity.x * 0.85f, rb.velocity.y);
        }

        // первый-второй прыжок
        if (lestJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForse);
            lestJump = false;
        }

        // повотор персонажа
        if (moveX > 0 && !faceRight)
            flip();
        else
        if (moveX < 0 && faceRight)
            flip();


        //Debug.Log(rb.velocity);



    }

    public void Die(bool show_death_text = false)
    {
        if (!canIDeath) return;
        if (death) return;
        death = true;
        GetComponent<AnimatorController>().death = true;
        transform.Find("Weapon").GetComponent<Weapon>().death = true;

        //lvlController.FinishScene();


        //timerBar.stopIt = true;
        //if (show_death_text)
        //    text_not.text = texts_death[Random.Range(0, texts_death.Length)];
    }


    public void flip()
    {
        faceRight = !faceRight;
        transform.Rotate(0f, 180f, 0f);
        //canv.GetComponent<RectTransform>().Rotate(0f, 180f, 0f);
        //canv2.GetComponent<RectTransform>().Rotate(0f, 180f, 0f);
        //sr.flipX = !sr.flipX;
    }


    public void StopMoveAtMoment(float timer = 0f)
    {
        StartCoroutine(StopMoveAtMomentCor(timer));
    }

    IEnumerator StopMoveAtMomentCor(float timer)
    {
        while (timer >= 0)
        {
            timer -= Time.fixedDeltaTime;
            rb.velocity = new Vector2(0, 0);
            yield return new WaitForFixedUpdate();
        }
    }

}
