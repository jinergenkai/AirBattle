using Assets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    public float moveSpeed = 10.0f; 

    private float horizontalInput;
    private float verticalInput;
    private Vector3 movement;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //animation :))
        if (horizontalInput != 0)
            transform.transform.rotation = Quaternion.Euler(0, horizontalInput * 45, -horizontalInput * 15);

        /* check when out of screen */
        if (Util.isOutOfScreen(Util.getCorners(Camera.main), transform.position)) {
            MoveWhenOutOfScreen();
        }

        movement = new Vector3(horizontalInput, verticalInput, 0.0f) * moveSpeed * Time.deltaTime;
        transform.position += movement;
    }

    private void MoveWhenOutOfScreen()
    {
        var corners = Util.getCorners(Camera.main);
        if (transform.position.x < corners[0].x && horizontalInput < 0)
        {
            horizontalInput = 0;
        }
        else if (transform.position.x > corners[3].x && horizontalInput > 0)
        {
            horizontalInput = 0;
        }
        
        if (transform.position.y < corners[0].y && verticalInput < 0)
        {
            verticalInput = 0;
        }
        else if (transform.position.y > corners[3].y && verticalInput > 0)
        {
            verticalInput = 0;
        }
    }
}
//     ／))      /)／)
//    (・   )o  (・   )o
//From Jinergenkai with love

