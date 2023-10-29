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


public class OpponentScript : MonoBehaviour
{
    public Animator animator;

    public Text score; 

    private int hp = 5;
    private bool isDead = false;

    public int Hp
    {
        get => hp;
        set => hp = value;
    }



    void Start()
    {
        score = GameObject.Find("Score").GetComponent<Text>();

        InvokeRepeating("EnemyFire", 1, 5);
    }

    void Update()
    {
        
    }

    void EnemyFire()
    {
        if (isDead) return;
        GameObject bullet = Instantiate(Resources.Load("Prefab/EnemyBullet01"), transform.position, Quaternion.identity) as GameObject;
        bullet.GetComponent<EnemyBullet01Script>().Initialize(15, 180);
    }

    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isDead) return;
        if (other.CompareTag("Bullet"))
        {
            switch (other.name)
            {
                case "ExcaliburBullet(Clone)":
                    hp -= 20;
                    break;
                case "Dragon(Clone)":
                    hp -= 40;
                    break;
                case "Bullet(Clone)":
                    Destroy(other.gameObject);
                    hp--;
                    break;
            }
            if (hp > 1) return;

            animator.SetBool("IsDead", true);
            isDead = true;
            Destroy(gameObject, 0.4f);

            score.text = "" + (int.Parse(score.text) + 1);
        }

    }

}
