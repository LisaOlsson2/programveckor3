using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Alt : MonoBehaviour
{
    float speed = 6;
    float spawnX;
    int direction = 1;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spawnX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < spawnX - 3)
        {
            direction = 1;
        }
        if (transform.position.x > spawnX + 3)
        {
            direction = 2;
        }

        if (direction == 1)
        {
            animator.SetInteger("en2", 0);
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        if (direction == 2)
        {
            animator.SetInteger("en2", 1);
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        }
    }
}
