using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame : MonoBehaviour
{

    Player player;
    int frame;
    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        frame = player.frame;
    }

    // Update is called once per frame
    void Update()
    {
        if (frame == 1)
        {
            if (player.animationTimer > 1)
            {
                Destroy(gameObject);
            }
        }
        if (frame == 2)
        {
            if (player.animationTimer > 2)
            {
                Destroy(gameObject);
            }
        }
        if (frame == 3)
        {
            if (player.animationTimer > 3)
            {
                Destroy(gameObject);
            }
        }
        if (frame == 4)
        {
            if (player.animationTimer > 4)
            {
                Destroy(gameObject);
            }
        }
        if (frame == 5)
        {
            if (player.animationTimer > 5)
            {
                Destroy(gameObject);
            }
        }
        if (frame == 6)
        {
            if (player.animationTimer > 6)
            {
                Destroy(gameObject);
            }
        }
    }
}
