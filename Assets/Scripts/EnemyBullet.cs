using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    EnemyAlt enemy;
    int direction;

    // Start is called before the first frame update
    void Start()
    {
        enemy = FindObjectOfType<EnemyAlt>();
        direction = enemy.direction;
    }

    // Update is called once per frame
    void Update()
    {
        if (direction == 1)
        {
            transform.position += new Vector3(10, 0, 0) * Time.deltaTime;
        }
        if (direction == 2)
        {
            transform.position += new Vector3(-10, 0, 0) * Time.deltaTime;
        }
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