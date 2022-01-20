using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Backstory : MonoBehaviour
{
    string backstory;
    public Text Text;
    public float line;
    float timer;

    [SerializeField]
    KeyCode Next;
    [SerializeField]
    KeyCode Next2;

    // Start is called before the first frame update
    void Start()
    {
        Text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Text.text = backstory;
        timer += Time.deltaTime;


        if (Input.GetKey(Next) || Input.GetKey(Next2))
        {
            if (timer > 0.3)
            {
                line += 1;
                timer = 0;
            }
        }
        if (line == 1)
        {
            backstory = "The forest is under threat by mysterious and dangerous creatures, possibly triggered by the corruption.";
        }
        if (line == 2)
        {
            backstory = "Save the forest by bringing the sacred ruby to its original and rightful owner, the tree god, without it being stolen from(insert name of antagonist)’s evil creatures.";
            ;
        }
        if (line == 3)
        {
            backstory = "The story begins with an old wise man running to you for help.He tells you about the ongoing dangers in the forest and that they need your help to save it.";
        }
        if (line == 4)
        {
            backstory = "You don’t believe the man until he shows you the legendary sacred ruby, the one you only thought was an old myth.";
        }
        if (line == 5)
        {
            backstory = "He tells you that you need to bring it back to the “tree god” and all evil creatures and spirits will disappear.";
        }
        if (line == 6)
        {
            backstory = "But he warns you.";
        }
        if (line == 7)
        {
            backstory = "You are under great danger and you will risk your life during this task.With a little bit of thinking you decide to accept the challenge and save the forest.";

        }
        if (line >= 8)
        {

            SceneManager.LoadScene("Dialogue", LoadSceneMode.Single);
        }
    }
}
