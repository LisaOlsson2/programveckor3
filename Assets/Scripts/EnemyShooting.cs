using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    float timer;
    [SerializeField]
    GameObject Bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 3)
        {
            Instantiate(Bullet, transform.position, Quaternion.identity);
            timer = 0;
        }
    }
}
