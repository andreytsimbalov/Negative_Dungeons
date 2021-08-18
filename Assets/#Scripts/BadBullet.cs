﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadBullet : MonoBehaviour
{
    public float start_speed = 15f;
    public float speed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        speed = start_speed;
        rb = GetComponent<Rigidbody2D>();

        rb.rotation = transform.rotation.eulerAngles.z;
        rb.velocity = Vec2rot(Vector2.right, transform.rotation.eulerAngles.z) * speed;

        StartCoroutine(RotateBullet());
        Destroy(gameObject, 20f);
    }


    IEnumerator RotateBullet()
    {
        while (true)
        {
            rb.rotation -= 360.0f * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

    Vector2 Vec2rot(Vector2 vec, float angle)
    {
        angle = angle * Mathf.PI / 180f;
        Vector2 res = Vector2.zero;
        res.x = vec.x * Mathf.Cos(angle) - vec.y * Mathf.Sin(angle);
        res.y = vec.x * Mathf.Sin(angle) + vec.y * Mathf.Cos(angle);


        return res;
    }


}