using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruby : MonoBehaviour
{
    Player player;
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
        if (player.ruby == true)
        {
            transform.position = new Vector3(cam.transform.position.x - 6.5f, cam.transform.position.y - 3.8f, 0);
        }
        else
            transform.position = new Vector3(-27, -9.8f, 0);
    }
}
