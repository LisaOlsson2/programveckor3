using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP : MonoBehaviour
{
    [SerializeField]
    int x;

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
        if (x == player.xp)
        {
            transform.position = new Vector3(cam.transform.position.x - 5, cam.transform.position.y + 3.88f, 0);
        }
        else
            transform.position = new Vector3(-28, -3.82f, 0);
    }
}
