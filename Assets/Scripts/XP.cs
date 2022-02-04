using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Lisa

public class XP : MonoBehaviour
{
    // represents how full the xp bar is, there are twelve sprites and they all have their own int
    [SerializeField]
    int x;

    // to get the cameras position
    CameraFollow cam;

    // to get the players xp
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<CameraFollow>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (x == player.xp)
        {
            // where they'll be in relation to the cameras position
            transform.position = new Vector3(cam.transform.position.x - 5, cam.transform.position.y + 3.88f, 0);
        }
        else
            transform.position = new Vector3(-28, -3.82f, 0); // being out of view when they don't represent the players xp
    }
}
