using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Theo
public class BossShooting : MonoBehaviour
{
    float timer;
    float timer2;
    [SerializeField]
    GameObject Bullet;


    // Update is called once per frame
    void Update()
    {
        timer2 += Time.deltaTime;
        timer += Time.deltaTime;
        if (timer <= 5)
        {
            if (timer2 >= 0.1)
            {
                Instantiate(Bullet, transform.position, Quaternion.identity); //bossen skjuter snabbt i 5 sekunder sedan väntar den i 5 sekunder
                timer2 = 0;
            }
        }
        if (timer >= 10)
        {
            timer = 0;
        }
        

    }
}
