using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class XpText : MonoBehaviour
{
    public Text xpText;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xpText.text = "Level: " + GameObject.Find("Enemy").GetComponent<LevelSystem>().level.ToString() + " xp: " + GameObject.Find("Enemy").GetComponent<LevelSystem>().xp.ToString() + "/" + GameObject.Find("Enemy").GetComponent<LevelSystem>().levelUp.ToString();
    }
}
