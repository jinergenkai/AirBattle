using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPointPlayerScript : MonoBehaviour
{
    private Sprite heartSprite;
    private Sprite noHeartSprite;
    void Start()
    {
        heartSprite = Resources.Load<Sprite>("heart");
        noHeartSprite = Resources.Load<Sprite>("noheart");


    }

    // Update is called once per frame
    void Update()
    {
        //get hp from player
        GameObject player = GameObject.Find("Player");
        PlayerScript playerScript = player.GetComponent<PlayerScript>();
        for (int i = 0; i < 3; i++)
        {
            transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = (i < playerScript.hp) ? heartSprite : noHeartSprite;
        }


    }
}
