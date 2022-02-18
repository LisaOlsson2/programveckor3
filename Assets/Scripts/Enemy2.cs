using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    Player player;
    [SerializeField, Range(0, 5)]
    float speed;
    float hp = 5;
    private Transform Targets;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        Targets = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Targets.position, speed * Time.deltaTime); // Oscar - Denna kod gör så att enemyn ska ändra sin position till den "Targets" har vilket i detta fall betyder att den går emot spelaren
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PBullet")
        {
            hp -= 1;
            if (hp <= 0)
            {
                if (player.scene.name == "Level 1")
                {
                    player.xp += 6;
                }
                if (player.scene.name == "Level 3")
                {
                    player.xp += 1;
                }
                Destroy(gameObject);
            }
        }
    }
}
