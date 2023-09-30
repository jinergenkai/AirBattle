using UnityEngine;
using System.Collections;
public class Spawn : MonoBehaviour
{
    public float dichBegin;
    public float dichDelay;
    public GameObject dich;
    public Transform OponentPos;

    // Use this for initialization
    void Start()
    {
        dichBegin = Random.Range(1f, 3f);
        dichDelay = Random.Range(2f, 3f);
        InvokeRepeating("SpawnDich", dichBegin, dichDelay);
    }
    // Update is called once per frame
    void Update()
    {

    }
    void SpawnDich()
    {
        Instantiate(dich, OponentPos.position, Quaternion.Euler(0f, 0f, 180f));
    }
}