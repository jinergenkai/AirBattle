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

    void Start()
    {
        score = GameObject.Find("Score").GetComponent<Text>();
    }

    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isDead) return;
        if (other.CompareTag("Bullet"))
        {
            switch (other.name)
            {
                case "ExcaliburBullet(Clone)":
                    hp -= 2;
                    break;
                case "Dragon(Clone)":
                    hp -= 10;
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
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            if (other.GetComponent<PlayerScript>().hp >= 1)
            {
                other.GetComponent<PlayerScript>().hp--;
                return;
            }
        }
    }

}
