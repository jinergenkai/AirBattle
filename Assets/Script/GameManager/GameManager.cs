using Assets;
using System;
using System.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Assets.Util;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public Text gameover;
    public Text spaceToPlay;
    public Text StageText;
    public GameObject player;

    private float stageDurationTime = 2.0f;

    public GameObject score;
    private int currentGameLevel = 0;

    public int playerLevel = 1;


    public float OpponentBegin = 0;
    public float OpponentDelay = 1f;
    public GameObject Opponent;
    float CurrentEnemyObject = 0, MaxEnemyInStage = 0, EnemyGenerateCount = 0;


    public float BeginTimeGift = 0;
    public float DelayTimeGift = 0.5f;
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

    }

    // Update is called once per frame
    void Update()
    {
        CurrentEnemyObject = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (CurrentEnemyObject == 0 && EnemyGenerateCount == MaxEnemyInStage)
        {
            currentGameLevel++;
            StartNewStage();
        }
        StartOverGameEvent();
    }

    private void StartNewStage()
    {
        InitStage();
        StartCoroutine(ShowAndHideText("Stage " + currentGameLevel));
        CancelInvoke("SpawnEnemyEvent");
        CancelInvoke("SpawnGiftEvent");
    }

    private void InitStage()
    {
        EnemyGenerateCount = 0;
        MaxEnemyInStage += 10;
    }

    private IEnumerator ShowAndHideText(string textToDisplay)
    {
        StageText.text = textToDisplay;
        StageText.enabled = true;

        yield return new WaitForSeconds(stageDurationTime);

        StageText.enabled = false;
        InvokeRepeating("SpawnGiftEvent", BeginTimeGift, DelayTimeGift);
        InvokeRepeating("SpawnEnemyEvent", OpponentBegin, OpponentDelay);

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
        if (EnemyGenerateCount >= MaxEnemyInStage)
        {
            CancelInvoke("SpawnEnemyEvent");
            return;
        }
        EnemyGenerateCount++;

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