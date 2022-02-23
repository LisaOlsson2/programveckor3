using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Lisa

public class EnemyBullet : MonoBehaviour
{
    // to get the player's position
    Player player;

    float speed = 4;

    float bulletTimer;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        // moving the bullet
        transform.position += new Vector3(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y, 0).normalized * Time.deltaTime * speed;

        // destroying the bullet outside the borders
        if (transform.position.x > 100 || transform.position.x < -26 || transform.position.y < -12 || transform.position.y > 40)
        {
            Destroy(gameObject);
        }
        
        // Destroys the bullet after 5 sec flight time - Theo
        bulletTimer += Time.deltaTime; 
        if (bulletTimer >= 5)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject); // destroying the bullet when it hits something
    }
}