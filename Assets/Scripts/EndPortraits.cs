using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPortraits : MonoBehaviour
{
    [SerializeField]
    int portrait;

    EndDialogue dialogue;

    // Start is called before the first frame update
    void Start()
    {
        dialogue = FindObjectOfType<EndDialogue>();
        transform.position = new Vector3(-6.9f, -8, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (portrait == 1)
        {
            if (dialogue.line == 1 ||dialogue.line == 3 || dialogue.line == 5 || dialogue.line == 7)
            {
                transform.position = new Vector3(500f, 400f, 0);
            }
            else
                transform.position = new Vector3(-200f, -8, 0);
        }
        if (portrait == 2)
        {
            if (dialogue.line == 2)
            {
                transform.position = new Vector3(300f, 400f, 0);
            }
            else
                transform.position = new Vector3(-200f, -8, 0);
        }
        if (portrait == 3)
        {
            if (dialogue.line == 4 || dialogue.line == 6)
            {
                transform.position = new Vector3(300f, 400f, 0);
            }
            else
                transform.position = new Vector3(-200f, -8, 0);
        }
       
    }
}
