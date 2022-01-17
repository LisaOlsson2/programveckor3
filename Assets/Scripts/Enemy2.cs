using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    [SerializeField, Range(0, 5)]
    float speed;

    private Transform Targets;
    // Start is called before the first frame update
    void Start()
    {
        Targets = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Targets.position, speed * Time.deltaTime);
    }
}
