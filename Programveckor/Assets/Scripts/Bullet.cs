using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float speed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Enemy").GetComponent<Enemy>().goRight == true)
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        else if (GameObject.Find("Enemy").GetComponent<Enemy>().goRight == false)
        {
            transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
        }

        

    }
}
