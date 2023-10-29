using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovementScript : MonoBehaviour
{
    public float EnemySpeed = 7;
    private Vector3[] Directs = { new Vector3(0, 0), new Vector3(1, 0), new Vector3(-1, 0)};
    private int[] portion = { 6, 6, 6};
    private Vector3 CurrentDirect = new Vector3(0, -1);

    private Vector3[] corners;
    // Start is called before the first frame update
    void Start()
    {
        corners = Util.getCornersPlus(Camera.main);
        InvokeRepeating("ChangeDirection", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -9 || transform.position.x > 4)
        {
            ChangeDirection();
        }

        transform.position += CurrentDirect * Time.deltaTime * EnemySpeed;

    }
    void ChangeDirection()
    {
        CurrentDirect = Directs[Util.RandomByPortionArray(portion)];
    }
}
