using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public float moveSpeed = 5.0f; 

    public float bulletSpeed = 10;
    public GameObject bulletPrefab; 
    public Transform spawnPoint;
    void Start()
    {
    }


    void Update()
    {
        // bulletSpeed1 = 2;
        // Get input from WASD keys
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0.0f) * moveSpeed * Time.deltaTime;
        transform.position += movement;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    void Fire()
	{
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        //print(spawnPoint.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
}
