using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour
{
    public float EnemySpeed = 10;

    //private Vector3[] Directs = { new Vector3(0, 0) ,new Vector3(0,1), new Vector3(1,0),new Vector3(-1, 0), new Vector3(0, -1)};
    private Vector3[] Directs = { new Vector3(0, 0), new Vector3(1,0),new Vector3(-1, 0), new Vector3(0, -1)};
    private Vector3 CurrentDirect = new Vector3(0, 0);
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ChangeDirection", 2, 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += CurrentDirect * Time.deltaTime * EnemySpeed;
    }
    void ChangeDirection()
    {
        CurrentDirect = Directs[Random.Range(0, Directs.Length)];
    }
}
