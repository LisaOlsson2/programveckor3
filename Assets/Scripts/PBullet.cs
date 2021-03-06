using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Lisa

public class PBullet : MonoBehaviour
{
    float speed = 10;

    // the direction of the bullet
    Vector3 direction;

    // to get the direction
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        direction = player.direction; // making the direction the direction that was calculated in Player
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime; // movement

        // where it gets destroyed
        if (transform.position.y > 40 || transform.position.x < -26 || transform.position.x > 78)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject); // destroying it when it hits something
    }
}
