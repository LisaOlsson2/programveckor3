using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    float timer;
    [SerializeField]
    GameObject Bullet;


    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        if (timer >= 3 && GetComponent<Enemy>().goRight == true)
        {
            Instantiate(Bullet, transform.position = new Vector3(1, 0, 0), Quaternion.identity);
            timer = 0;
        }
        if (timer >= 3 && GetComponent<Enemy>().goRight == false)
        {
            Instantiate(Bullet, transform.position = new Vector3(-1, 0, 0), Quaternion.identity);
            timer = 0;
        }
    }
}
