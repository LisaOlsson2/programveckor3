using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float speed;
    public bool goRight;
    float hp = 3;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (goRight == true)
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        if (goRight == false)
        {
            transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
        }

        if (timer <= 1)
        {
            goRight = true;
            
        }
        if (timer >= 1)
        {
            goRight = false;
            if (timer >= 2)
            {
                timer = 0;
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
                Destroy(gameObject);
            }
        }
    }
}
