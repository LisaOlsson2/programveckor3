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
        if (dialogue.line == 19)
        {
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
