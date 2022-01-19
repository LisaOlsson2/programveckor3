using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    public float xp = 0;
    public float level = 1;
    public float levelUp;
    // Update is called once per frame
    void Update()
    {
        levelUp = level * 100;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PBullet")
        {
            xp += 5;
            if (xp >= levelUp)
            {
                level += 1;
                //damage + 1?
                //hp + 1?
            }
        }
    }

}
