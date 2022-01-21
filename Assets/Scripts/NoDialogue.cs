using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NoDialogue : MonoBehaviour
{
    string dialogue;
    public Text text;
    public float line;
    float timer;

    DialogueChoices square;

    [SerializeField]
    KeyCode Talk; 

    void Start()
    {
        square = FindObjectOfType<DialogueChoices>();
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = dialogue;
        timer += Time.deltaTime;

        if (Input.GetKey(Talk) && timer > 0.3)
        {
            line += 1;
            timer = 0;
        }

        if (line == 1)
        {
            dialogue = "Well that’s a shame, hope you have a good life!"; 
        }
       
       
    }

}
