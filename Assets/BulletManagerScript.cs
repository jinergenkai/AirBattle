using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManagerScript : MonoBehaviour
{

    GameObject player;
    GameObject bulletLeft;
    PlayerScript playerScript;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        bulletLeft = GameObject.Find("BulletLeft");
        playerScript = player.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        bulletLeft.transform.localScale = new Vector3(playerScript.bulletLeft / 30f, bulletLeft.transform.localScale.y, bulletLeft.transform.localScale.z);
    }
}
