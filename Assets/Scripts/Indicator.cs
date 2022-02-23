using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Lisa

public class Indicator : MonoBehaviour
{
    // for the camera's position
    CameraFollow cam;

    // to know what to indicate
    Player player;

    // an int to represent it
    [SerializeField]
    int thing; // 1 = key 2 = gun

    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<CameraFollow>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        // being in the corner when the player has the thing
        if (player.items == thing)
        {
            transform.position = new Vector3(cam.transform.position.x - 8, cam.transform.position.y - 4, 0);
        }
        else
            transform.position = new Vector3(-27, -10, 0); // being outside of where the player even can go when they don't have the thing
    }
}
