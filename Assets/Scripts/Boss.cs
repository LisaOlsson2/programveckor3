using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    [SerializeField]
    float speed;
    public bool goRight;
    float hp = 20;
    float timer;

    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (goRight == true)
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime; //Bossen rör sig åt höger ifall goRight = true - Theo
        }
        if (goRight == false)
        {
            transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime; //Bossen rör sig åt vänster ifall goRight = false - Theo
        }

        if (timer <= 2)
        {
            goRight = true;

        }
        if (timer >= 2)
        {
            goRight = false;
            if (timer >= 4)
            {
                timer = 0;  // goRight = true i 2 sekunder och false i 2 sekunder - Theo
            }
        }
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

