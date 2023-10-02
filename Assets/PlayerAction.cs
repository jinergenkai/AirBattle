using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerAction : MonoBehaviour
{
    public float moveSpeed = 5.0f; 

    public float bulletSpeed = 10;
    public GameObject bulletPrefab; 
    public Transform spawnPoint;
    public Text spaceToPlay;
    void Start()
    {
        Time.timeScale = 0;
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
            Time.timeScale = 1;
            spaceToPlay.gameObject.SetActive(false);
            Fire();
        }
    }

    void Fire()
	{
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
        //print(spawnPoint.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //ResetScene();
        }
    }



}
