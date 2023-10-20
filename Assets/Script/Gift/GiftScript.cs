using Assets;
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Util;

public class GiftScript : MonoBehaviour
{
    private float moveSpeed = 5f;
    private e_giftType giftType;
    GameObject player;
    PlayerScript playerScript;
    
    public void Initialize(Sprite sprite, e_giftType giftType)
    {
        this.giftType = giftType;
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GiftController();
            Destroy(gameObject);
        }
    }

    private void GiftController()
    {
        switch(giftType)
        {
            case e_giftType.heartPlus: HeartPlusEffect(); break;
            case e_giftType.normalBullet: NormalBulletEffect(); break;
            case e_giftType.doubleBullet: DoubleBulletEffect(); break;
            case e_giftType.tripleBullet: TripleBulletEffect(); break;
            case e_giftType.crossBullet: CrossBulletEffect(); break;
            case e_giftType.slowBullet: SlowBulletEffect(); break;
                
        }
    }

    private void SlowBulletEffect()
    {
        playerScript.bulletType = e_bulletType.slowBullet;
        playerScript.bulletLeft = 30;
        playerScript.fireRate = 0.07f;
    }

    private void CrossBulletEffect()
    {
        playerScript.bulletType = e_bulletType.crossBullet;
        playerScript.bulletLeft = 30;
        playerScript.fireRate = 0.07f;
    }

    private void TripleBulletEffect()
    {
        playerScript.bulletType = e_bulletType.tripleBullet;
        playerScript.bulletLeft = 30;
        playerScript.fireRate = 0.07f;

    }

    private void DoubleBulletEffect()
    {
        playerScript.bulletType = e_bulletType.doubleBullet;
        playerScript.bulletLeft = 30;
        playerScript.fireRate = 0.07f;
    }

    private void NormalBulletEffect()
    {
        playerScript.bulletType = e_bulletType.normalBullet;
        playerScript.bulletLeft = 30;
        playerScript.fireRate = 0.07f;
    }

    private void HeartPlusEffect()
    {
        playerScript.hp = Math.Min(playerScript.hp + 1, 3);
    }
}