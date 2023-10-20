using UnityEngine;
using System.Collections;
using Assets;
using UnityEngine.UIElements;

public class SpawnOpponentScript : MonoBehaviour
{
    public float OpponentBegin;
    public float OpponentDelay;
    public GameObject Opponent;
    public Transform SpawnPosition;

    // Use this for initialization
    void Start()
    {
        //dichBegin = Random.Range(1f, 3f);
        OpponentBegin = 0;
        OpponentDelay = Random.Range(0.5f, 0.5f);
        InvokeRepeating("SpawnDich", OpponentBegin, OpponentDelay);
    }
    // Update is called once per frame
    void Update()
    {

    }
    void SpawnDich()
    {
        var cameraPosition = Util.getCorners(Camera.main);

        var rangeLeft = cameraPosition[2].x;
        var rangeRight = cameraPosition[3].x;
        var randomPosition = new Vector3(Random.Range(rangeLeft, rangeRight), cameraPosition[2].y);

        Instantiate(Opponent, randomPosition, Quaternion.Euler(0f, 0f, 180f));
    }
}