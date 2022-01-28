using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Player player;
    float speed = 4;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y, 0).normalized * Time.deltaTime * speed;


        if (transform.position.x > 26 || transform.position.x < -26)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}