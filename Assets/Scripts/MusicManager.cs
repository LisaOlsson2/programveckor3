using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ella 
public class MusicManager : MonoBehaviour
{

    [SerializeField]
    AudioSource AS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //anv�nder loop f�r att musiken ska loopa 
        if (AS.isPlaying == false)
        {
            AS.Play(); 
        }
        
    }
}
