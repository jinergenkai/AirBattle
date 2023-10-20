using System;
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

    public GameObject bulletPrefab; 
    public Transform spawnPoint;
    public Text spaceToPlay;
    public e_bulletType bulletType = e_bulletType.doubleBullet;

    public int hp = 3;
    public int bulletLeft = 20;

    private float lastFireTime = 0;
    private float bulletSpeed = 20;

    public float fireRate = 0.05f;
    private float TIME_REGAIN_ONE_BULLET = 0.2f;

    void Start()
    {
        Time.timeScale = 0;
        bulletPrefab = Resources.Load<GameObject>("Prefab/Bullet");
        InvokeRepeating("RegainBullet", 0, TIME_REGAIN_ONE_BULLET);
    }


    void Update()
    {
        // bulletSpeed1 = 2;
        // Get input from WASD keys

        if (Input.GetKey(KeyCode.Space))
        {
            //if (enemy.flagover == true)
            //{
            //    enemy.flagover = false;
            //    ResetScene();
            //}
            Time.timeScale = 1;
            spaceToPlay.gameObject.SetActive(false);
            if (Time.time - lastFireTime > fireRate)
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
            //case e_bulletType.excaliburBullet: ExcaliburBullet(); break;
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
        bulletPrefab = Resources.Load<GameObject>("Prefab/Bullet");
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
        bullet.GetComponent<BulletScript>().Initialize(5, 0);
    }

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
        if (bulletLeft < 30)
            bulletLeft++;
    }


}
//     ／))      /)／)
//    (・   )o  (・   )o
//From Jinergenkai with love

