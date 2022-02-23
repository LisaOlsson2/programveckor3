using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Lisa

public class Enemy2Alt : MonoBehaviour
{
    float speed = 6;
    float spawnX; // the x position where it starts
    int direction = 1; // 1 = right, 2 = left
    float health = 7;

    bool dmg;
    float timer;

    Player player;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        animator = GetComponent<Animator>();
        spawnX = transform.position.x; // saving the x position it starts in in spawnX
    }

    // Update is called once per frame
    void Update()
    {
        // changing the direction when it goes too far away from its starting position
        if (transform.position.x < spawnX - 3)
        {
            direction = 1;
        }
        if (transform.position.x > spawnX + 3)
        {
            direction = 2;
        }

        if (direction == 1 && dmg == false)
        {
            animator.SetInteger("en2", 0); // the right walking animation
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime; // moving to the right
        }
        if (direction == 2 && dmg == false)
        {
            animator.SetInteger("en2", 1);
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        }

        if (health <= 0 && dmg == false)
        {
            player.xp += 2;
            Destroy(gameObject);
        }

        // damage and death animations
        if (dmg == true)
        {
            if (direction == 1) // 
            {
                if (health <= 0) // death
                {
                    animator.SetInteger("en2", 4);
                }
                else // damage
                {
                    animator.SetInteger("en2", 3);
                }
            }
            if (direction == 2)
            {
                if (health <= 0)
                {
                    animator.SetInteger("en2", 5);
                }
                else
                {
                    animator.SetInteger("en2", 2);
                }
            }
            timer += Time.deltaTime;
        }
        if (timer >= 0.7)
        {
            dmg = false;
            timer = 0;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PBullet" && dmg == false)
        {
            dmg = true;
            health -= 1;
        }
    }
}
