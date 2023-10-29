using Assets;
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Util;

public class GiftScript : MonoBehaviour
{
    private float moveSpeed = 3f;
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
        }
        playerScript.bulletLeft = playerScript.MaxAmmunition;
    }

    private void NormalBulletEffect()
    {
        if (playerScript.bulletType == e_bulletType.infiniteBullet)
        {
            playerScript.BulletLevel++;
            return;
        }
        playerScript.bulletType++;
    }

    private void HeartPlusEffect()
    {
        playerScript.hp = Math.Min(playerScript.hp + 1, 3);
    }
}