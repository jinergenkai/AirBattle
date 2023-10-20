using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillScript : MonoBehaviour
{

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //when press 1
        if (Input.GetKey(KeyCode.J))
        {
            SkillJ();
        }
    }
    
    private void SkillJ()
    {

    }
}
