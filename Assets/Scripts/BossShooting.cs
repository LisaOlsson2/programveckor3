using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Theo
public class BossShooting : MonoBehaviour
{
    float timer;
    [SerializeField]
    GameObject Bullet;


    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer >= 3)
        {
            Instantiate(Bullet, transform.position, Quaternion.identity); //fienden skjuter var 3:e sekund
            timer = 0;
        }

    }
}
