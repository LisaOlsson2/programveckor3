using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Theo
public class EnemyShooting : MonoBehaviour
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
            Instantiate(Bullet, transform.position + new Vector3(0, 1, 0), Quaternion.identity); //fienden skjuter var 3:e sekund
            timer = 0;
        }
        
    }
}
