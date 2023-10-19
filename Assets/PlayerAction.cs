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
    //public OponentAction enemy;
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
            //if (enemy.flagover == true)
            //{
            //    enemy.flagover = false;
            //    ResetScene();
            //}
            Time.timeScale = 1;
            spaceToPlay.gameObject.SetActive(false);
            Fire();
        }
    }

    void Fire()
	{
        Quaternion bulletRotation = Quaternion.Euler(0, 45, 0);

        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position + new Vector3(0.5f, 0, 0), Quaternion.identity);

        GameObject bullet1 = Instantiate(bulletPrefab, spawnPoint.position + new Vector3(-0.5f, 0, 0), Quaternion.identity);
        //print(spawnPoint.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //ResetScene();
        }
    }

    void ResetScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }


}
