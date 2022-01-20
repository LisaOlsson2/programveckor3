using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    string dialogue;
    public Text text;
    public float line;
    float timer;

    DialogueChoices square;

    [SerializeField]
    KeyCode talk;

    // Start is called before the first frame update
    void Start()
    {
        square = FindObjectOfType<DialogueChoices>();
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = dialogue;
        timer += Time.deltaTime;


        if (Input.GetKey(talk) && timer > 0.3)
        {
            line += 1;
            timer = 0;
        }

        if (line == 1)
        {
            dialogue = "Hello you";
        }

        if (line == 2)
        {
            dialogue = "Hi, can I help you?";
        }

        if (line == 3)
        {
            dialogue = "Yes, I want you to help me save the enchanted forest";
        }

        if (line == 4)
        {
            dialogue = "Funny joke old man, but I’m not really the type of person to “save an enchanted  forest”";
        }

        if (line == 5)
        {
            dialogue = "I’m not joking";
        }

        if (line == 6)
        {
            dialogue = "Well how do I “save” the forest";
        }

        if (line == 7)
        {
            dialogue = "For that you need the sacred ruby";
        }

        if (line == 8)
        {
            dialogue = "The sacred ruby…..BAHHAHAHHAHAHAH.. You are a very funny old man.";
        }

        if (line == 9)
        {
            dialogue = "Where would a cranky old man like you find THE sacred ruby";
        }

        if (line == 10)
        {
            dialogue = "Laugh again";
        }

        if (line == 11)
        {
            dialogue = "WHAT";
        }

        if (line == 12)
        {
            dialogue = "Well what do you say now?";
        }

        if (line == 13)
        {
            dialogue = "Easy, will do";
        }

        if (line == 14)
        {
            dialogue = "It’s not an easy task kid, the enchanted forest is a very dangerous place, especially with the sacred ruby in your hand.";
        }

        if (line == 15)
        {
            dialogue = "(Name of antagonist) is after this ruby as well";
        }

        if (line == 16)
        {
            dialogue = "(Name of antagonist)!!!!";
        }

        if (line == 17)
        {
            dialogue = "Do you accept the challenge?";
        }

        if (line == 18)
        {
            dialogue = "YES\nNO";
            square.transform.position = new Vector3(1.7f, -1.75f, 0);
            line += 1;
        }

        if (line >= 20)
        {
            square.transform.position = new Vector3(1.7f, 6, 0);
            SceneManager.LoadScene("Lisa", LoadSceneMode.Single);
        }

    }
}
       