// name spaces or code libarys
// .net frame work 
using System.Collections;
using System.Collections.Generic;
// MonoBehavior is from the Unity name space
using UnityEngine;
// : stands for extends or inherits
// Monobehavior is a unity specific term allow the drag and drop of scripts or behaviors into game objects to control them. 
//MonoBehaviour comes with void Start() and void Update()
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // take the current positon as the start of the game (0,0,0)
        // vector 3 uses new keyword
        transform.position = new Vector3(0, 0, 0);
        
    }

    // Update is called once per frame ) (about 60 frames per second)
    void Update()
    {
        // this is the same as 
       // transform.Translate(new Vector3(1, 0, 0) * 5 * real time);
        // this 
       transform.Translate(Vector3.right * 5 *  Time.deltaTime );
     
    }
}
