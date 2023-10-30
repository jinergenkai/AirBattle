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


public class BossScript : MonoBehaviour
{
    public Animator animator;

    public Text score;

    public GameObject hpShow;
    public int hp = 1000;
    public int MaxHp = 1000;
    private bool isDead = false;

    public int Hp
    {
        get => hp;
        set => hp = value;
    }

    void Start()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Hp = gameManager.currentGameLevel * 1000 / 10;
        MaxHp = gameManager.currentGameLevel * 1000 / 10;
        score = GameObject.Find("Score").GetComponent<Text>();
        GameObject.Find("BossHP").GetComponent<BossHPScript>().isShow = true;
        InvokeRepeating("EnemyFire", 1, 0.5f);
        InvokeRepeating("BossLazer", 1, 4f);
    }

    void Update()
    {

    }

    void EnemyFire()
    {
        if (isDead) return;
        GameObject bullet = Instantiate(Resources.Load("Prefab/EnemyBullet02"), transform.position + new Vector3(5, -1, 0), Quaternion.identity) as GameObject;
        GameObject bullet1 = Instantiate(Resources.Load("Prefab/EnemyBullet02"), transform.position + new Vector3(-5, -1, 0), Quaternion.identity) as GameObject;
        bullet.GetComponent<EnemyBullet02Script>().Initialize(10, 180);
        bullet1.GetComponent<EnemyBullet02Script>().Initialize(10, 180);
    }

    void BossLazer()
    {
        if (isDead) return;
        GameObject bullet = Instantiate(Resources.Load("Prefab/lazer"), transform.position + new Vector3(0, -15.73f, 0), Quaternion.identity) as GameObject;
        bullet.GetComponent<LazerScript>().Initialize(Time.time, 1, -90);
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (isDead) return;
        if (other.CompareTag("Bullet"))
        {
            switch (other.name)
            {
                case "ExcaliburBullet(Clone)":
                    hp -= 10;
                    break;
                case "Dragon(Clone)":
                    hp -= 20;
                    break;
                case "Bullet(Clone)":
                    Destroy(other.gameObject);
                    hp--;
                    break;
            }
            if (hp > 1) return;

            animator.SetBool("IsDead", true);
            isDead = true;
            GameObject.Find("BossHP").transform.position = new Vector3(0, 50, 0);
            GameObject.Find("BossHP").GetComponent<BossHPScript>().isShow = false;
            GameObject.Find("BossHP").GetComponent<BossHPScript>().isFirstShow = true;

            Destroy(gameObject, 2f);

            score.text = "" + (int.Parse(score.text) + 1);
        }

    }

}
