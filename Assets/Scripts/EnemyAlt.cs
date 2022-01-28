using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlt : MonoBehaviour
{
    Player player;
    Animator animator;
    [SerializeField]
    private GameObject eBullet;

    public int direction;
    float timer;
    float speed = 2;
    float health = 5;

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
        if (player.transform.position.x > transform.position.x)
        {
            direction = 1;
            if (player.transform.position.x - transform.position.x < 3)
            {
                animator.SetInteger("enemy1", 0);
            }
            else
                animator.SetInteger("enemy1", 5);
        }
        if (player.transform.position.x < transform.position.x)
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
        if (player.transform.position.x - transform.position.x < 3 && player.transform.position.x - transform.position.x > -3)
        {
            transform.position += new Vector3(player.transform.position.x - transform.position.x, 0, 0).normalized * speed * Time.deltaTime;
        }

        if (timer > 3)
        {
            timer = 0;
            if (direction == 1)
            {
                Instantiate(eBullet, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
            }
            if (direction == 2)
            {
                Instantiate(eBullet, transform.position + new Vector3(-1, 0, 0), Quaternion.identity);
            }
        }

        if (health <= 0)
        {
            player.xp += 2;
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PBullet")
        {
            health -= 1;
        }
    }
}
