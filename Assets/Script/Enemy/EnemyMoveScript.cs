using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour
{
    public float EnemySpeed = 7;

    private Transform target;

    //private Vector3[] Directs = { new Vector3(0, 0) ,new Vector3(0,1), new Vector3(1,0),new Vector3(-1, 0), new Vector3(0, -1)};
    private Vector3[] Directs = {new Vector3(0, 0), new Vector3(1,0),new Vector3(-1, 0), new Vector3(0, -1), new Vector3(0, 1)};
    private int[] portion = {10, 6, 6, 4, 5};
    private Vector3 CurrentDirect = new Vector3(0, 0);

    private Vector3[] corners;
    // Start is called before the first frame update
    void Start()
    {
        corners = Util.getCornersPlus(Camera.main);
        target = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("ChangeDirection", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Util.isOutOfScreen(corners, transform.position))
        {
            ChangeDirection();
        }

        transform.position += CurrentDirect * Time.deltaTime * EnemySpeed;

    }
    void ChangeDirection()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position);
            direction.Normalize();
            Directs[0] = (direction);
        }    

        CurrentDirect = Directs[Util.RandomByPortionArray(portion)];
    }
}
