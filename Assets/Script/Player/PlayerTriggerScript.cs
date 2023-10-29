using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Enemy"))
        {
            if (gameObject.GetComponent<PlayerScript>().isImmune) return;
            other.GetComponent<OpponentScript>().Hp -= 5;
            gameObject.GetComponent<PlayerScript>().isImmune = true;
            gameObject.GetComponent<PlayerScript>().hp--;
        }
        if (other.CompareTag("EnemyBullet"))
        {
            if (gameObject.GetComponent<PlayerScript>().isImmune) return;
            Destroy(other.gameObject);
            gameObject.GetComponent<PlayerScript>().isImmune = true;
            gameObject.GetComponent<PlayerScript>().hp--;
        }
    }
}
