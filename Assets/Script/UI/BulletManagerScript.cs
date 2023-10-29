using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManagerScript : MonoBehaviour
{

    GameObject player;
    GameObject bulletLeft;
    public GameObject ammunitionText;
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
        ammunitionText.GetComponent<UnityEngine.UI.Text>().text = playerScript.bulletLeft.ToString();
        bulletLeft.transform.localScale = new Vector3(playerScript.bulletLeft / 30f, bulletLeft.transform.localScale.y, bulletLeft.transform.localScale.z);
    }
}
