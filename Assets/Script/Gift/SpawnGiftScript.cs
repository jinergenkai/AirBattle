using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Util;

public class SpawnGiftScript : MonoBehaviour
{
    public float BeginTime;
    public float DelayTime;
    public GameObject Gift;

    private Sprite[] spriteGifts = new Sprite[(int) e_giftType.maxGiftType];
    void Awake()
    {
        for (int i = 0; i < (int) e_giftType.maxGiftType; i++)
        {
            spriteGifts[i] = Resources.Load<Sprite>("gift/" + nameGiftAssets[i]);
        }
    }

    void Start()
    {
        BeginTime = 0;
        DelayTime = Random.Range(1f, 2f);
        InvokeRepeating("SpawnGift", BeginTime, DelayTime);


    }
    void Update()
    {

    }
    void SpawnGift()
    {
        var cameraPosition = Util.getCorners(Camera.main);

        var rangeLeft = cameraPosition[2].x;
        var rangeRight = cameraPosition[3].x;
        var randomPosition = new Vector3(Random.Range(rangeLeft, rangeRight), cameraPosition[2].y);
        GameObject giftSpawn = Instantiate(Gift, randomPosition, Quaternion.Euler(0f, 0f, 0f));

        //random gift type
        var giftType = Random.Range(0, (int) e_giftType.maxGiftType);

        //set sprite for gift
        giftSpawn.GetComponent<GiftScript>().Initialize(spriteGifts[giftType], (e_giftType) giftType);
    }
}



