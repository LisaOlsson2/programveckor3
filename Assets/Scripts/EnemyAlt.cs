using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Lisa

public class EnemyAlt : MonoBehaviour
{
    // for the player's position so that it can do stuff in the right direction, and also to increase the player's xp on death
    Player player;

    Animator animator;
    
    [SerializeField]
    private GameObject eBullet;

    // movement
    int direction; // 1 = right, 2 = left
    float speed = 2;

    float timer; // shooting timer
    
    float health = 5;

    bool dmg; // true for 0.7 seconds at a time. During this time it plays its damage animation and can't take damage
    float dmgTimer;
    

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // idle animations
        if (player.transform.position.x > transform.position.x && timer <= 2.3 && dmg == false)
        {
            direction = 1;
            if (player.transform.position.x - transform.position.x < 3)
            {
                animator.SetInteger("enemy1", 0);
            }
            else
            {
                animator.SetInteger("enemy1", 5);
            }
        }
        if (player.transform.position.x < transform.position.x && timer <= 2.3 && dmg == false)
        {
            direction = 2;
            if (player.transform.position.x - transform.position.x > -3)
            {
                animator.SetInteger("enemy1", 1);
            }
            else
            {
                animator.SetInteger("enemy1", 3);
            }
        }

        // moving towards the player if it's within 3 x coordinates
        if (player.transform.position.x - transform.position.x < 3 && player.transform.position.x - transform.position.x > -3 && dmg == false)
        {
            transform.position += new Vector3(player.transform.position.x - transform.position.x, 0, 0).normalized * speed * Time.deltaTime;
        }

        // shooting animations
        if (timer > 2.3 && dmg == false)
        {
            if (direction == 1)
            {
                animator.SetInteger("enemy1", 4);
            }
            if (direction == 2)
            {
                animator.SetInteger("enemy1", 2);
            }
        }

        // shooting
        if (timer > 3 && dmg == false)
        {
            timer = 0;
            if (direction == 1)
            {
                Instantiate(eBullet, transform.position + new Vector3(1, 0.6f, 0), Quaternion.identity);
            }
            if (direction == 2)
            {
                Instantiate(eBullet, transform.position + new Vector3(-1, 0.6f, 0), Quaternion.identity);
            }
        }
        

        // dying
        if (health <= 0 && dmg == false)
        {
            player.xp += 2;
            Destroy(gameObject);
        }

        // death and damage animations
        if (dmg == true)
        {
            if (direction == 1)
            {
                if (health <= 0) // death
                {
                    animator.SetInteger("enemy1", 7);
                }
                else // damage
                {
                    animator.SetInteger("enemy1", 8);
                }
            }
            if (direction == 2)
            {
                if (health <= 0)
                {
                    animator.SetInteger("enemy1", 6);
                }
                else
                {
                    animator.SetInteger("enemy1", 9);
                }
            }
            dmgTimer += Time.deltaTime;
        }
        if (dmgTimer >= 0.7)
        {
            dmg = false; // so that it can take damage again, or die if its health has reached 0
            dmgTimer = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // losing health when the players bullet hits it
        if (collision.gameObject.tag == "PBullet" && dmg == false)
        {
            dmg = true;
            health -= 1;
        }
    }
}
