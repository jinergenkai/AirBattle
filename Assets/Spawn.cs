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
        dichBegin = Random.Range(3f, 5f);
        dichDelay = Random.Range(3f, 5f);
        InvokeRepeating("SpawnDich", dichBegin, dichDelay);
    }
    // Update is called once per frame
    void Update()
    {

    }
    void SpawnDich()
    {
        Instantiate(dich, OponentPos.position, OponentPos.rotation);
    }
}