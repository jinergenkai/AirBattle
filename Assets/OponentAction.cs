using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;
using static UnityEngine.RuleTile.TilingRuleOutput;


public class OponentAction : MonoBehaviour
{

    private float latestDirectionChangeTime;
    private readonly float directionChangeTime = 1.5f;
    private float characterVelocity = 5f;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;

    public Text score;
    public Text gameover;
    public bool flagover = false;

    private (int, int)[] direct = { (0, 0) ,(0,1), (1,0),(-1, 0), (0, -1)};
    private int exceptX = 0, exceptY = 0;
    private int nextDirect = 0;

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
        int index;
        //do
        //{
        //    index = UnityEngine.Random.Range(0, 4);
        //}
        //while (index == exceptX || index == exceptY);

        if (nextDirect == 0)
        {
            index = UnityEngine.Random.Range(0, 4);
        }
        else index = nextDirect;

        movementDirection = new Vector2(direct[index].Item1, direct[index].Item2).normalized;
        movementPerSecond = movementDirection * characterVelocity;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (flagover == true)
            {
                flagover = false;
                gameover.text = "0";
                ResetScene();
            }
            //Time.timeScale = 1;
            //gameover.gameObject.SetActive(false);
        }

        Vector2 current = gameObject.transform.position;

        Boolean newDirect = false;
        if (current.y <= -13.37f)
        {
            exceptY = 4;
            nextDirect = 1;
            newDirect = true;
        }
        else if (current.y >= -2.5f)
        {
            exceptY = 1;
            nextDirect = 4;
            newDirect = true;
        }
        else
        {
            exceptY = 0;
        }

        if (current.x >= 8.5f)
        {
            exceptX = 2;
            nextDirect = 3;
            newDirect = true;
        }
        else if (current.x <= -12.5f)
        {
            exceptX = 3;
            nextDirect = 2;
            newDirect = true;
        }
        else
        {
            exceptX = 0;
        }
        if (!newDirect)
        {
            nextDirect = 0;
        }
        

        //if the changeTime was reached, calculate a new movement vector
        if (newDirect || Time.time - latestDirectionChangeTime > directionChangeTime)
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            score = FindAnyObjectByType<Text>();
            score.text = "" + (int.Parse(score.text) + 1);
        }
        print("haha");
        if (other.CompareTag("Player"))
        {
            print("thua cuoc");
            //Destroy(gameObject);
            Time.timeScale = 0;
            gameover = FindAnyObjectByType<Text>();
            gameover.gameObject.SetActive(true);
            gameover.text = "GameOver, Score: " + gameover.text;
            flagover = true;
            //Thread.Sleep(3000);
            //ResetScene();
        }

        //if (other.CompareTag("ScreenZone"))
        //{
        //    movementDirection = -movementDirection;
        //}
        //if (other.CompareTag("Enemy"))
        //{
        //    movementDirection = -movementDirection;
        //}
    }
    void ResetScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

}
