using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    public float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(speed, speed, speed);
    }
}
