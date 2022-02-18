using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Lisa

public class DialogueChoices : MonoBehaviour
{
    [SerializeField]
    KeyCode up;

    [SerializeField]
    KeyCode down;

    Dialogue dialogue;

    // Start is called before the first frame update
    void Start()
    {
        dialogue = FindObjectOfType<Dialogue>();
        transform.position = new Vector3(1.7f, 6, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // it's moved at first in the dialogue script
        // everything in this script could have been in the dialogue script actually

        if (dialogue.line == 19)
        {
            // moving up and down to choose "YES" or "NO"
            if (Input.GetKey(up))
            {
                transform.position = new Vector3(1.7f, -1.75f, 0);
            }
            if (Input.GetKey(down))
            {
                transform.position = new Vector3(1.7f, -2.25f, 0);
            }
        }
      
    }
}
