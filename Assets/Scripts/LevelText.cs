using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelText : MonoBehaviour
{
    public Text _levelText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _levelText.text = GameObject.Find("Enemy").GetComponent<LevelSystem>().xp.ToString();
    }
}
