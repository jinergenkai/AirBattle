using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;


public class OponentAction : MonoBehaviour
{

    private float latestDirectionChangeTime;
    private readonly float directionChangeTime = 3f;
    private float characterVelocity = 2f;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;

    //public float moveSpeed = 5.0f;
    //private Transform target; // Đối tượng mục tiêu (ví dụ: người chơi)

    void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Player").transform;
        latestDirectionChangeTime = 0f;
        calcuateNewMovementVector();
    }

    void calcuateNewMovementVector()
    {
        //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy
        movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        movementPerSecond = movementDirection * characterVelocity;
    }

    void Update()
    {
        //if the changeTime was reached, calculate a new movement vector
        if (Time.time - latestDirectionChangeTime > directionChangeTime)
        {
            latestDirectionChangeTime = Time.time;
            calcuateNewMovementVector();
        }

        //move enemy: 
        transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime),
        transform.position.y + (movementPerSecond.y * Time.deltaTime));

        //if (target != null)
        //{
        //    // Xác định hướng di chuyển đến mục tiêu
        //    Vector3 direction = -(target.position - transform.position);
        //    direction.Normalize(); // Đảm bảo hướng có độ dài là 1

        //    // Di chuyển đối thủ theo hướng mục tiêu
        //    transform.Translate(direction * moveSpeed * Time.deltaTime);
        //}
        //else
        //{
        //    transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        //}

    }
}
