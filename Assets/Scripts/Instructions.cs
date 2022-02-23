using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Lisa

public class Instructions : MonoBehaviour
{
    // what the instructions shall be
    public string instructions = "";

    // to change the text
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = instructions; // having the text as the text in instructions
    }
}
