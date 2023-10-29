using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillScript : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerScript player = gameObject.GetComponent<PlayerScript>();
        //when press 1
        if (Input.GetKeyDown(KeyCode.J) && player.score >= 50)
        {
            if (player.bulletLeft >= 10)
            {
                player.bulletLeft -= 10;
                ExcaliburBullet();
            }
        }
        if (Input.GetKeyDown(KeyCode.K) && player.score >= 150)
        {
            if (player.bulletLeft >= 30)
            {
                player.bulletLeft -= 30;
                CallDragon();
            }
        }
        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    if (player.bulletLeft > 20)
        //    {
        //        player.bulletLeft -= 20;
        //        ShieldExploision();
        //    }
        //}
    }

    private void ShieldExploision()
    {
        GameObject bulletPrefab = Resources.Load<GameObject>("Prefab/Shield");
        GameObject excalibur1 = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }

    private void ExcaliburBullet()
    {
        GameObject bulletPrefab = Resources.Load<GameObject>("Prefab/excaliburBullet");
        GameObject excalibur1 = Instantiate(bulletPrefab, transform.position + new Vector3(2f, 0, 0), Quaternion.identity);
        GameObject excalibur2 = Instantiate(bulletPrefab, transform.position + new Vector3(-2f, 0, 0), Quaternion.identity);
        //excalibur1.GetComponent<ExcaliburBulletScript>().Initialize(bulletSpeed, 0);
        //excalibur2.GetComponent<ExcaliburBulletScript>().Initialize(bulletSpeed, 0);
    }

    private void CallDragon()
    {
        GameObject bulletPrefab = Resources.Load<GameObject>("Prefab/Dragon");
        GameObject excalibur1 = Instantiate(bulletPrefab, new Vector3(transform.position.x, -19, 0), Quaternion.identity);

    }
}
