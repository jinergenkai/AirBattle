using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExcaliburBulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //tranform up
        transform.position += new Vector3(0, 1, 0) * Time.deltaTime * 10;
        float currentRotation = transform.rotation.eulerAngles.y;
        float newRotation = currentRotation + 200f * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, newRotation, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ScreenZone"))
        {
            Destroy(gameObject);
        }
    }
}
