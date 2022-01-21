using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2 : MonoBehaviour
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

        if (player.transform.position.x > -16.9 && player.transform.position.x < 23.5)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, -10);
        }

        if (player.transform.position.y > -8)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y, -10);
        }
    }
}
