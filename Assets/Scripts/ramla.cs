using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Oscar
public class ramla : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ramla")
        {
            Destroy(gameObject);
        }
        // En simpel kod gjord f�r att om man ramlar ner i h�let p� scenen 2.1 s� ska spelaren d�.
    }
}
