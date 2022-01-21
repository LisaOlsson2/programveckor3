using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float speed;
    public bool goRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (goRight == true)
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        if (goRight == false)
        {
            transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
        }

        if (transform.position.x <= -3)
        {
            goRight = true;
        }
        else if(transform.position.x >= 3)
        {
            goRight = false;
        }
    }
}
