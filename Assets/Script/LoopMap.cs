using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEditor;
using UnityEngine;

public class ScreenGenerator : MonoBehaviour
{
    public float generatorSpeed = 10f;
    public float msY = -84.0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector2.down * generatorSpeed * Time.deltaTime);
        if (gameObject.transform.position.y <= msY)
        {
            gameObject.transform.position = new Vector3(0, 0, 0);
        }
    }
}
