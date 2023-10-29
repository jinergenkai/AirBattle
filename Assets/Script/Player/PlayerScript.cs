using Assets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Assets.Util;
using static BulletScript;

public class PlayerScript : MonoBehaviour
{

    public GameObject bulletPrefab; 
    public Transform spawnPoint;
    public Text spaceToPlay;
    public Text gameover;
    public e_bulletType bulletType = e_bulletType.doubleBullet;
    public int BulletLevel = 0;

    public int score;

    public int hp = 3;
    public int bulletLeft = 20;

    private float lastFireTime = 0;
    private float bulletSpeed = 20;

    public float fireRate = 0.1f;
    private float TIME_REGAIN_ONE_BULLET = 0.2f;
    public int MaxAmmunition = 30;

    public bool isStopFire = false;

    public bool isImmune = false;
    public float immuneTime = 1.5f;
    public float immuneStartTime = 0f;
    public bool effectImmuneHide = false;

    void Start()
    {
        bulletPrefab = Resources.Load<GameObject>("Prefab/Bullet");
        InvokeRepeating("RegainBullet", 0, TIME_REGAIN_ONE_BULLET);
    }


    void Update()
    {
        score = int.Parse(GameObject.Find("Score").GetComponent<Text>().text);
        MaxAmmunition = 30 + score % 10 * 4;

        if (Input.GetKey(KeyCode.Space))
        {
            if (!isStopFire && Util.isOutDurationTime(lastFireTime, fireRate))
            {
                lastFireTime = Time.time;
                useBullet();
                Fire();
            }
        }

        if (isImmune)
        {
            if (immuneStartTime <= 0)
            {
                immuneStartTime = Time.time;
            }
            else
            {
                if (Util.isOutDurationTime(immuneStartTime, immuneTime))
                {
                    isImmune = false;
                    gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    immuneStartTime = -1;
                }
                else
                {
                    gameObject.GetComponent<SpriteRenderer>().enabled = effectImmuneHide;
                    effectImmuneHide = !effectImmuneHide;
                }
            }

        }

    }

    void Fire()
	{
        //controller
        switch(bulletType)
        {
            case e_bulletType.normalBullet: NormalBullet(); break;
            case e_bulletType.doubleBullet: DoubleBullet(); break;
            case e_bulletType.tripleBullet: TripleBullet(); break;
            case e_bulletType.crossBullet: CrossBullet(); break;
            case e_bulletType.infiniteBullet: InifiniteBullet(); break;
            default: break;
        }
    }


    void useBullet()
    {
        if (bulletLeft <= 0)
        {
            isStopFire = true;
            return;
        }
        bulletLeft--;
    }

    //  ┓   ┓┓            
    //  ┣┓┓┏┃┃┏┓╋  ╋┓┏┏┓┏┓
    //  ┗┛┗┻┗┗┗ ┗  ┗┗┫┣┛┗ 
    //               ┛┛   

    private void CrossBullet()
    {
        bulletPrefab = Resources.Load<GameObject>("Prefab/Bullet");
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position + new Vector3(0.6f, 0, 0), Quaternion.identity);
        GameObject bullet1 = Instantiate(bulletPrefab, spawnPoint.position + new Vector3(0.6f, 0, 0), Quaternion.identity);
        GameObject bullet2 = Instantiate(bulletPrefab, spawnPoint.position + new Vector3(-0.6f, 0, 0), Quaternion.identity);
        GameObject bullet3 = Instantiate(bulletPrefab, spawnPoint.position + new Vector3(-0.6f, 0, 0), Quaternion.identity);
        bullet.GetComponent<BulletScript>().Initialize(bulletSpeed, -45);
        bullet1.GetComponent<BulletScript>().Initialize(bulletSpeed, -135);
        bullet2.GetComponent<BulletScript>().Initialize(bulletSpeed, 45);
        bullet3.GetComponent<BulletScript>().Initialize(bulletSpeed, 135);
    }
    private void InifiniteBullet()
    {
        int NumberOfBullet = BulletLevel + (int)e_bulletType.infiniteBullet + 1;
        bulletPrefab = Resources.Load<GameObject>("Prefab/Bullet");
        GameObject[] bullets = new GameObject[NumberOfBullet];

        int startBullet = 0;
        if (NumberOfBullet % 2 == 0)
        {
            bullets[0] = Instantiate(bulletPrefab, spawnPoint.position + new Vector3(0.6f, 0, 0), Quaternion.identity);
            bullets[1] = Instantiate(bulletPrefab, spawnPoint.position + new Vector3(-0.6f, 0, 0), Quaternion.identity);
            bullets[0].GetComponent<BulletScript>().Initialize(bulletSpeed, 0);
            bullets[1].GetComponent<BulletScript>().Initialize(bulletSpeed, 0);
            startBullet = 2;
        }
        else
        {
            bullets[0] = Instantiate(bulletPrefab, spawnPoint.position + new Vector3(0.6f, 0, 0), Quaternion.identity);
            bullets[1] = Instantiate(bulletPrefab, spawnPoint.position + new Vector3(-0.6f, 0, 0), Quaternion.identity);
            bullets[2] = Instantiate(bulletPrefab, spawnPoint.position + new Vector3(0, 0, 0), Quaternion.identity);
            bullets[0].GetComponent<BulletScript>().Initialize(bulletSpeed, 0);
            bullets[1].GetComponent<BulletScript>().Initialize(bulletSpeed, 0);
            bullets[2].GetComponent<BulletScript>().Initialize(bulletSpeed, 0);
            startBullet = 3;

        }
        int angle = 0;
        for (int i = startBullet, j = NumberOfBullet - 1; i < j; i++, j--)
        {
            angle += 17;
            angle %= 90;

            bullets[i] = Instantiate(bulletPrefab, spawnPoint.position + new Vector3(0.0f, 0, 0), Quaternion.identity);
            bullets[i].GetComponent<BulletScript>().Initialize(bulletSpeed, angle);

            bullets[j] = Instantiate(bulletPrefab, spawnPoint.position + new Vector3(0.0f, 0, 0), Quaternion.identity);
            bullets[j].GetComponent<BulletScript>().Initialize(bulletSpeed, -angle);

        }
    }

    private void TripleBullet()
    {
        bulletPrefab = Resources.Load<GameObject>("Prefab/Bullet");
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position + new Vector3(0.6f, 0, 0), Quaternion.identity);
        GameObject bullet1 = Instantiate(bulletPrefab, spawnPoint.position + new Vector3(0, 0, 0), Quaternion.identity);
        GameObject bullet2 = Instantiate(bulletPrefab, spawnPoint.position + new Vector3(-0.6f, 0, 0), Quaternion.identity);
        bullet.GetComponent<BulletScript>().Initialize(bulletSpeed, -45);
        bullet1.GetComponent<BulletScript>().Initialize(bulletSpeed, 0);
        bullet2.GetComponent<BulletScript>().Initialize(bulletSpeed, 45);
    }

    private void DoubleBullet()
    {
        bulletPrefab = Resources.Load<GameObject>("Prefab/Bullet");
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position + new Vector3(0.6f, 0, 0), Quaternion.identity);
        GameObject bullet1 = Instantiate(bulletPrefab, spawnPoint.position + new Vector3(-0.6f, 0, 0), Quaternion.identity);
        bullet.GetComponent<BulletScript>().Initialize(bulletSpeed, 0);
        bullet1.GetComponent<BulletScript>().Initialize(bulletSpeed, 0);
    }

    private void NormalBullet()
    {
        bulletPrefab = Resources.Load<GameObject>("Prefab/Bullet");
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
        bullet.GetComponent<BulletScript>().Initialize(bulletSpeed, 0);
    }
    private void RegainBullet()
    {
        if (isStopFire)
        {
            if (bulletLeft >= 10)
                isStopFire = false;
            bulletLeft = Mathf.Min(bulletLeft + 2, MaxAmmunition);
        }
        else if (bulletLeft < MaxAmmunition)
        {
            bulletLeft++;
        }
    }


}
//     ／))      /)／)
//    (・   )o  (・   )o
//From Jinergenkai with love

