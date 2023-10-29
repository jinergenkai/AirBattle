using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerScript : MonoBehaviour
{
    private float speed = 2f;
    private float angle = 180f;
    private float damage = 1f;
    private float cost = 1;
    private float fireRate = 0.05f;

    public float StartTime, DurationTime;
    //private e_bulletType bulletType;

    //public void Initialize(float speed, float angle)
    //{
    //    this.angle = angle;
    //    this.speed = speed;
    //}
    public void Initialize(float start, float duration, float angle)
    {
        //print("Start time" + start);
        this.StartTime = start;
        this.DurationTime = duration;
        this.angle = angle;
    }
    public void Initialize(float speed, float angle, float damage = 1, float cost = 1, float fireRate = 0.05f)
    {
        this.angle = angle;
        this.speed = speed;
        this.damage = damage;
        this.cost = cost;
        this.fireRate = fireRate;
    }

    void Update()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 0, angle);
        if (Time.time - StartTime > DurationTime)
        {
            //print("destroy time" + Time.time);
            Destroy(gameObject);
        }
    }
}
