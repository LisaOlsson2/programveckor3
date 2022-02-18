using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
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
            Destroy(gameObject); //ifall skottet har funnits i 2 sekunder s� f�rst�rs det - Theo
        }
        Targets = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); 
        transform.position = Vector3.MoveTowards(transform.position, Targets.position, speed * Time.deltaTime); //Oscar - som med Enemy2 koden s� �r detta gjort s� att skotten ska r�ra sig emot spelaren.

    }

        

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject); //om skottet tr�ffar n�got f�rst�rs det (kollision med andra skott och fiender �r avst�ngt) - Theo
        
        /*if (collision.gameObject.tag == "Player")
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
        }*/
        
    }
}
