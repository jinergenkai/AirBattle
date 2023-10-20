using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExcaliburBulletScript : MonoBehaviour
{
    private float speed = 5f;
    private float angle = 0f;
    private float damage = 1f;
    private float cost = 1;
    private float fireRate = 1;
    //private e_bulletType bulletType;

    public void Initialize(float speed, float angle)
    {
        this.angle = angle;
        this.speed = speed;
    }
    public void Initialize(float speed, float angle, float damage = 1, float cost = 1, float fireRate = 0.05f)
    {
        this.angle = angle;
        this.speed = speed;
        this.damage = damage;
        this.cost = cost;
        this.fireRate = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        //tranform up
        transform.position += new Vector3(0, 1, 0) * Time.deltaTime * 10;
        float currentRotation = transform.rotation.eulerAngles.y;
        float newRotation = currentRotation + 200f * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, newRotation, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ScreenZone"))
        {
            Destroy(gameObject);
        }
    }
}
