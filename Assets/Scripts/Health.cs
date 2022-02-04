using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Lisa

public class Health : MonoBehaviour
{
    // so that it can have a sprite assigned to it
    [SerializeField]
    int h;

    // it's all pretty much the same as with xp

    CameraFollow cam;
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
        if (h == player.health)
        {
            transform.position = new Vector3(cam.transform.position.x - 7.5f, cam.transform.position.y + 4, 0);
        }
        else
            transform.position = new Vector3(-28, -3.7f, 0);
    }
}
