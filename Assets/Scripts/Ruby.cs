using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Lisa

// just to show if the player has the ruby or not

public class Ruby : MonoBehaviour
{
    // to check if the player has the ruby
    Player player;

    // to get the cameras position
    CameraFollow cam;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        cam = FindObjectOfType<CameraFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.ruby == true) // if the player has the ruby
        {
            // where it'll be in relation to the camera
            transform.position = new Vector3(cam.transform.position.x - 6.5f, cam.transform.position.y - 3.8f, 0);
        }
        else
            transform.position = new Vector3(-27, -9.8f, 0); // being out of view when the player doesn't have the ruby
    }
}
