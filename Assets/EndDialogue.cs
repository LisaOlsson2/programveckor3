using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndDialogue : MonoBehaviour
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
            dialogue = "Look at you, you made it";
        }

        if (line == 2)
        {
            dialogue = "Old man, what are you doing here?";
        }

        if (line == 3)
        {
            dialogue = "What do you mean what am I doing here? I told you to return the ruby to the tree god";
        }

        if (line == 4)
        {
            dialogue = "Yeah I know what of course, but where is he?";
        }

        if (line == 5)
        {
            dialogue = "I am the tree god my child";
        }

        if (line == 6)
        {
            dialogue = "But if you are the tree god? why did you tell me to bring it all the way here?";
        }

        if (line == 7)
        {
            dialogue = "This road is too dangerous for an old man like me to complete on his own while holding the worlds most sacred item, now give it to me so I can save the forest";
        }
       
        if (line == 8)
        {
            dialogue = "YES\nNO";
            square.transform.position = new Vector3(1.7f, -1.75f, 0);
            line += 1;
        }
       //if (line >= 9)
       //{
            //square.transform.position = new Vector3(1.7f, 6, 0);
            //SceneManager.LoadScene("Lisa", LoadSceneMode.Single);
      //}
    }


}
