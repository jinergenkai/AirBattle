using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMoveScript : MonoBehaviour
{
    private float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move up
        gameObject.transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
