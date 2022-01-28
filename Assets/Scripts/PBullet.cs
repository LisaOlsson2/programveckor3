using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBullet : MonoBehaviour
{
    float speed = 10;
    Vector3 direction;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        direction = player.direction;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        if (transform.position.y > 40 || transform.position.x < -26 || transform.position.x > 26 && player.scene.name == "Lisa")
        {
            Destroy(gameObject);
        }
        if (transform.position.y > 40 || transform.position.x < -26 || transform.position.x > 26 && player.scene.name == "Level 1")
        {
            Destroy(gameObject);
        }
        if (transform.position.y > 40 || transform.position.x < -26 || transform.position.x > 26 && player.scene.name == "Level 2")
        {
            Destroy(gameObject);
        }
        if (transform.position.y > 40 || transform.position.x < -26 || transform.position.x > 78 && player.scene.name == "Level 3")
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
