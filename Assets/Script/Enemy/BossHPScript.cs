using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHPScript : MonoBehaviour
{
    GameObject boss;
    GameObject bossHpLeft;
    BossScript BossScript;
    public bool isShow = false;
    public bool isFirstShow = true;
    // Start is called before the first frame update
    void Start()
    {
        bossHpLeft = GameObject.Find("BossLeft");
    }

    // Update is called once per frame
    void Update()
    {
        if (isShow)
        {
            if (isFirstShow)
            {
                isFirstShow = false;
                boss = GameObject.Find("CuteBoss(Clone)");
                BossScript = boss.GetComponent<BossScript>();
                gameObject.transform.localPosition = new Vector3(-2.0101f, 13.14f, 0.1078319f);
            }
        bossHpLeft.transform.localScale = new Vector3(BossScript.Hp / (float)BossScript.MaxHp, bossHpLeft.transform.localScale.y, bossHpLeft.transform.localScale.z);
        }
    }
}
