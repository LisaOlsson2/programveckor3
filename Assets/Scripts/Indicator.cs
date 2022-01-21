using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    CameraFollow cam;
    Player player;

    [SerializeField]
    int thing;

    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<CameraFollow>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.items == thing)
        {
            transform.position = new Vector3(cam.transform.position.x - 8, cam.transform.position.y - 4, 0);
        }
        else
            transform.position = new Vector3(-27, -10, 0);
    }
}
