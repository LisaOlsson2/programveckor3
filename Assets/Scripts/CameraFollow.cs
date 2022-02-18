using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Lisa

public class CameraFollow : MonoBehaviour
{
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        // all the ifs exist so that the camera only follows the player within the borders of the scene
        if (player.transform.position.x > -16.9 && player.transform.position.x < 16.9 && player.scene.name == "Lisa")
        {
            // following the player left and right
            transform.position = new Vector3(player.transform.position.x, transform.position.y, -10);
        }
        if (player.transform.position.x > -16.9 && player.transform.position.x < 16.9 && player.scene.name == "Level 1")
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, -10);
        }
        if (player.transform.position.x > -16.9 && player.transform.position.x < 32 && player.scene.name == "Level 2")
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, -10);
        }
        if (player.transform.position.x > -16.9 && player.transform.position.x < 32 && player.scene.name == "Level 2.1")
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, -10);
        }
        if (player.transform.position.x > -16.9 && player.transform.position.x < 72 && player.scene.name == "Level 3")
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, -10);
        }
        if (player.transform.position.x > -16.9 && player.transform.position.x < 72 && player.scene.name == "Boss Battle")
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, -10);
        }

        // they all have the ground on the same y coordinate
        if (player.transform.position.y > -8)
        {
            // following the player up and down
            transform.position = new Vector3(transform.position.x, player.transform.position.y, -10);
        }
    }
}
