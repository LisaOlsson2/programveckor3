using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Theo
    [SerializeField]
    float speed;
    private Transform Targets;
    float timer;
    float hp = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 2)
        {
            Destroy(gameObject);
        }
        Targets = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        transform.position = Vector3.MoveTowards(transform.position, Targets.position, speed * Time.deltaTime);
        
    }

        

    
    private void OnCollisionEnter2D(Collision2D collision)
    {

        
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        
        if (collision.gameObject.tag == "PBullet")
        {
            hp -= 1;
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
