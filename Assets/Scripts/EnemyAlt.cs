using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlt : MonoBehaviour
{
    Player player;
    Animator animator;
    [SerializeField]
    private GameObject eBullet;

    int direction;
    float timer;
    float speed = 2;
    float health = 5;

    bool dmg;
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
        if (player.transform.position.x > transform.position.x && timer <= 2.3 && dmg == false)
        {
            direction = 1;
            if (player.transform.position.x - transform.position.x < 3)
            {
                animator.SetInteger("enemy1", 0);
            }
            else
                animator.SetInteger("enemy1", 5);
        }
        if (player.transform.position.x < transform.position.x && timer <= 2.3 && dmg == false)
        {
            direction = 2;
            if (player.transform.position.x - transform.position.x > -3)
            {
                animator.SetInteger("enemy1", 1);
            }
            else
                animator.SetInteger("enemy1", 3);
        }

        timer += Time.deltaTime;
        if (player.transform.position.x - transform.position.x < 3 && player.transform.position.x - transform.position.x > -3 && dmg == false)
        {
            transform.position += new Vector3(player.transform.position.x - transform.position.x, 0, 0).normalized * speed * Time.deltaTime;
        }

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
                    animator.SetInteger("enemy1", 7);
                }
                else
                    animator.SetInteger("enemy1", 8);
            }
            if (direction == 2)
            {
                if (health <= 0)
                {
                    animator.SetInteger("enemy1", 6);
                }
                else
                    animator.SetInteger("enemy1", 9);
            }
            dmgTimer += Time.deltaTime;
        }
        if (dmgTimer >= 0.7)
        {
            dmg = false;
            dmgTimer = 0;
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
