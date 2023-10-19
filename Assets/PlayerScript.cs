﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Assets.Util;
using static BulletScript;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 5.0f; 

    public GameObject bulletPrefab; 
    public Transform spawnPoint;
    public Text spaceToPlay;
    public e_bulletType bulletType = e_bulletType.doubleBullet;

    public int hp = 3;
    public int bulletLeft = 20;

    private float lastFireTime = 0;
    private float bulletSpeed = 20;

    private readonly float TIME_BETWEEN_EACH_FIRE = 0.05f;
    private readonly float TIME_REGAIN_ONE_BULLET = 0.4f;

    void Start()
    {
        Time.timeScale = 0;

        //regain bullet each time
        InvokeRepeating("RegainBullet", 0, TIME_REGAIN_ONE_BULLET);
    }


    void Update()
    {
        // bulletSpeed1 = 2;
        // Get input from WASD keys
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput != 0)
        {
            transform.transform.rotation = Quaternion.Euler(0, horizontalInput * 45, -horizontalInput * 15);
        }

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0.0f) * moveSpeed * Time.deltaTime;
        transform.position += movement;

        if (Input.GetKey(KeyCode.Space))
        {
            //if (enemy.flagover == true)
            //{
            //    enemy.flagover = false;
            //    ResetScene();
            //}
            Time.timeScale = 1;
            spaceToPlay.gameObject.SetActive(false);
            if (Time.time - lastFireTime > TIME_BETWEEN_EACH_FIRE)
            {
                Fire();
                lastFireTime = Time.time;
            }
        }



    }

    void Fire()
	{
        if (bulletLeft <= 0)
        {
            return;
        }
        bulletLeft--;
        //controller
        switch(bulletType)
        {
            case e_bulletType.normalBullet: NormalBullet(); break;
            case e_bulletType.doubleBullet: DoubleBullet(); break;
            case e_bulletType.tripleBullet: TripleBullet(); break;
            case e_bulletType.crossBullet: CrossBullet(); break;
            case e_bulletType.slowBullet: SlowBullet(); break;
            default: break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //ResetScene();
        }
    }

    void ResetScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }


    //  ┓   ┓┓            
    //  ┣┓┓┏┃┃┏┓╋  ╋┓┏┏┓┏┓
    //  ┗┛┗┻┗┗┗ ┗  ┗┗┫┣┛┗ 
    //               ┛┛   
    private void SlowBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
        bullet.GetComponent<BulletScript>().Initialize(5, 0);
    }

    private void CrossBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position + new Vector3(0.6f, 0, 0), Quaternion.identity);
        GameObject bullet1 = Instantiate(bulletPrefab, spawnPoint.position + new Vector3(0.6f, 0, 0), Quaternion.identity);
        GameObject bullet2 = Instantiate(bulletPrefab, spawnPoint.position + new Vector3(-0.6f, 0, 0), Quaternion.identity);
        GameObject bullet3 = Instantiate(bulletPrefab, spawnPoint.position + new Vector3(-0.6f, 0, 0), Quaternion.identity);
        bullet.GetComponent<BulletScript>().Initialize(bulletSpeed, -45);
        bullet1.GetComponent<BulletScript>().Initialize(bulletSpeed, -135);
        bullet2.GetComponent<BulletScript>().Initialize(bulletSpeed, 45);
        bullet3.GetComponent<BulletScript>().Initialize(bulletSpeed, 135);
    }

    private void TripleBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position + new Vector3(0.6f, 0, 0), Quaternion.identity);
        GameObject bullet1 = Instantiate(bulletPrefab, spawnPoint.position + new Vector3(0, 0, 0), Quaternion.identity);
        GameObject bullet2 = Instantiate(bulletPrefab, spawnPoint.position + new Vector3(-0.6f, 0, 0), Quaternion.identity);
        bullet.GetComponent<BulletScript>().Initialize(bulletSpeed, -45);
        bullet1.GetComponent<BulletScript>().Initialize(bulletSpeed, 0);
        bullet2.GetComponent<BulletScript>().Initialize(bulletSpeed, 45);
    }

    private void DoubleBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position + new Vector3(0.6f, 0, 0), Quaternion.identity);
        GameObject bullet1 = Instantiate(bulletPrefab, spawnPoint.position + new Vector3(-0.6f, 0, 0), Quaternion.identity);
        bullet.GetComponent<BulletScript>().Initialize(bulletSpeed, 0);
        bullet1.GetComponent<BulletScript>().Initialize(bulletSpeed, 0);
    }

    private void NormalBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
        bullet.GetComponent<BulletScript>().Initialize(bulletSpeed, 0);
    }

    private void RegainBullet()
    {
        if (bulletLeft < 30)
            bulletLeft++;
    }


}
//     ／))      /)／)
//    (・   )o  (・   )o
//From Jinergenkai with love

