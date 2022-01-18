using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portraits : MonoBehaviour
{
    [SerializeField]
    int portrait;

    Dialogue dialogue;

    // Start is called before the first frame update
    void Start()
    {
        dialogue = FindObjectOfType<Dialogue>();
        transform.position = new Vector3(-6.9f, -8, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (portrait == 1)
        {
            if (dialogue.line == 2 || dialogue.line == 18)
            {
                transform.position = new Vector3(-6.9f, -2.9f, 0);
            }
            else
                transform.position = new Vector3(-6.9f, -8, 0);
        }
        if (portrait == 2)
        {
            if (dialogue.line == 13)
            {
                transform.position = new Vector3(-6.9f, -2.9f, 0);
            }
            else
                transform.position = new Vector3(-6.9f, -8, 0);
        }
        if (portrait == 3)
        {
            if (dialogue.line == 8)
            {
                transform.position = new Vector3(-6.9f, -2.9f, 0);
            }
            else
                transform.position = new Vector3(-6.9f, -8, 0);
        }
        if (portrait == 4)
        {
            if (dialogue.line == 4 || dialogue.line == 6 || dialogue.line == 9)
            {
                transform.position = new Vector3(-6.9f, -2.9f, 0);
            }
            else
                transform.position = new Vector3(-6.9f, -8, 0);
        }
        if (portrait == 5)
        {
            if (dialogue.line == 11 || dialogue.line == 16)
            {
                transform.position = new Vector3(-6.9f, -2.9f, 0);
            }
            else
                transform.position = new Vector3(-6.9f, -8, 0);
        }
        if (portrait == 6)
        {
            if (dialogue.line == 10 || dialogue.line == 12 || dialogue.line == 14 || dialogue.line == 15 || dialogue.line == 17)
            {
                transform.position = new Vector3(-6.9f, -2.9f, 0);
            }
            else
                transform.position = new Vector3(-6.9f, -8, 0);
        }
        if (portrait == 7)
        {
            if (dialogue.line == 1 || dialogue.line == 3 || dialogue.line == 5 || dialogue.line == 7)
            {
                transform.position = new Vector3(-6.9f, -2.9f, 0);
            }
            else
                transform.position = new Vector3(-6.9f, -8, 0);
        }
    }
}
