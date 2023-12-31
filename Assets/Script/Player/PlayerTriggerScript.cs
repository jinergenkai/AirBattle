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
        var playerScript = gameObject.GetComponent<PlayerScript>();
        if (other.CompareTag("Enemy"))
        {
            if (gameObject.GetComponent<PlayerScript>().isImmune) return;
            other.GetComponent<OpponentScript>().Hp -= 5;
            PlayerGetDamage(); 
        }
        if (other.CompareTag("EnemyBullet"))
        {
            if (gameObject.GetComponent<PlayerScript>().isImmune) return;
            PlayerGetDamage(); 
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("EnemyLazer"))
        {
            var start = other.GetComponent<LazerScript>().StartTime;
            var duration = other.GetComponent<LazerScript>().DurationTime;
            if (Time.time < start + 0.2f || Time.time > start + 0.4f) return;
            if (gameObject.GetComponent<PlayerScript>().isImmune) return;
            PlayerGetDamage(); 
        }
    }
    private void PlayerGetDamage()
    {
        var playerScript = gameObject.GetComponent<PlayerScript>();
        playerScript.isImmune = true;
        playerScript.hp--;
        playerScript.BulletLevel = Mathf.Max(Mathf.FloorToInt(playerScript.BulletLevel / 5), 0);
    }
}
