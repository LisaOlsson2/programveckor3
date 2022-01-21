using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBullet3 : MonoBehaviour
{
    float speed = 10;
    Vector3 direction;
    PlayerLvl3 player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerLvl3>();
        direction = player.direction;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        if (transform.position.y > 40 || transform.position.x < -26 || transform.position.x > 78)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}