using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Lisa

public class Enemy2Alt : MonoBehaviour
{
    float speed = 6;
    float spawnX;
    int direction = 1;
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
        spawnX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
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
            animator.SetInteger("en2", 0);
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
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

        if (dmg == true)
        {
            if (direction == 1)
            {
                if (health <= 0)
                {
                    animator.SetInteger("en2", 4);
                }
                else
                    animator.SetInteger("en2", 3);
            }
            if (direction == 2)
            {
                if (health <= 0)
                {
                    animator.SetInteger("en2", 5);
                }
                else
                    animator.SetInteger("en2", 2);
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
