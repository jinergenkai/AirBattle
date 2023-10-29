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
            Destroy(other.gameObject);
            PlayerGetDamage(); 
        }
    }
    private void PlayerGetDamage()
    {
        var playerScript = gameObject.GetComponent<PlayerScript>();
        playerScript.isImmune = true;
        playerScript.hp--;
        playerScript.BulletLevel = Mathf.Max(Mathf.FloorToInt(playerScript.BulletLevel / 2), 0);
    }
}
