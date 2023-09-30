using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;


    void Update()
    {
        // Di chuyển viên đạn theo hướng trước
        // transform.Translate(Vector3.forward * speed * Time.deltaTime);
        gameObject.transform.Translate(Vector2.up * speed * Time.deltaTime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("1");
        if (collision.gameObject.CompareTag("TriggerZone"))
        {
            Destroy(gameObject);
        }
    }


}