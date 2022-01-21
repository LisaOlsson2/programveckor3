using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlt : MonoBehaviour
{
    Player player;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x - transform.position.x < 3)
        {

        }
    }
}
