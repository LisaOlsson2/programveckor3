using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDmgAndXp : MonoBehaviour
{
    public float hp = 5;
    public float xp = 0;
    public float level = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            hp -= level;
            if (hp <= 0)
            {
                xp += 10;
                if (xp >= 100)
                {
                    level += 1;
                }
                Destroy(gameObject);
            }
        }
    }

}
