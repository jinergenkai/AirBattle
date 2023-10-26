using Assets;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Assets.Util;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public Text gameover;
    public Text spaceToPlay;
    public GameObject player;




    public float OpponentBegin = 0;
    public float OpponentDelay = 1f;
    public GameObject Opponent;


    public float BeginTimeGift = 0;
    public float DelayTimeGift = 3;
    public GameObject Gift;
    private Sprite[] spriteGifts = new Sprite[(int)e_giftType.maxGiftType];


    void Awake()
    {
        //loadGift
        for (int i = 0; i < (int)e_giftType.maxGiftType; i++)
        {
            spriteGifts[i] = Resources.Load<Sprite>("gift/" + nameGiftAssets[i]);
        }
    }

    void Start()
    {
        //Start Game Event
        Time.timeScale = 0;
        gameover.enabled = false;
        spaceToPlay.enabled = true;

        //Oponent
        InvokeRepeating("SpawnEnemyEvent", OpponentBegin, OpponentDelay);

        //Gift
        InvokeRepeating("SpawnGiftEvent", BeginTimeGift, DelayTimeGift);


    }

    // Update is called once per frame
    void Update()
    {
        StartOverGameEvent();
    }

    private void SpawnGiftEvent()
    {
        var cameraPosition = Util.getCorners(Camera.main);

        var rangeLeft = cameraPosition[2].x;
        var rangeRight = cameraPosition[3].x;
        var randomPosition = new Vector3(Random.Range(rangeLeft, rangeRight), cameraPosition[2].y);
        GameObject giftSpawn = Instantiate(Gift, randomPosition, Quaternion.Euler(0f, 0f, 0f));

        //random gift type
        var giftType = Random.Range(0, (int)e_giftType.maxGiftType);

        //set sprite for gift
        giftSpawn.GetComponent<GiftScript>().Initialize(spriteGifts[giftType], (e_giftType)giftType);
    }

    private void SpawnEnemyEvent()
    {
        var cameraPosition = Util.getCorners(Camera.main);

        var rangeLeft = cameraPosition[2].x;
        var rangeRight = cameraPosition[3].x;
        var randomPosition = new Vector3(Random.Range(rangeLeft, rangeRight), cameraPosition[2].y);

        Instantiate(Opponent, randomPosition, Quaternion.Euler(0f, 0f, 180f));
    }

    void ResetScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
    void StartOverGameEvent()
    {

        //Start - Over Game Event
        if (Input.GetKey(KeyCode.Space))
        {
            Time.timeScale = 1;
            spaceToPlay.enabled = false;
        }
        if (Input.GetKey(KeyCode.R))
        {
            ResetScene();
        }
        if (player.GetComponent<PlayerScript>().hp == 0)
        {
            gameover.enabled = true;
            Time.timeScale = 0;
        }
    }
}
