using Assets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float speed = 5f;
    private float angle = 0f;
    //private e_bulletType bulletType;

    public void Initialize(float speed, float angle)
    {
        this.angle = angle;
        this.speed = speed;
    }

    void Update()
    {
        //gameObject.transform.Translate(util.Rotate(new Vector2(0, 1), angle) * speed * Time.deltaTime);
        gameObject.transform.rotation = Quaternion.Euler(0, 0, angle);
        gameObject.transform.Translate(Vector2.up * speed * Time.deltaTime); 
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ScreenZone"))
        {
            Destroy(gameObject);
        }
    }


}