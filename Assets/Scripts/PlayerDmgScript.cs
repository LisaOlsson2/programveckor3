using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDmgScript : MonoBehaviour
{
    public float hp = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            hp -= 1;
            
        }
        if (collision.gameObject.tag == "Enemy2")
        {
            hp -= 2;
        }
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }


}
