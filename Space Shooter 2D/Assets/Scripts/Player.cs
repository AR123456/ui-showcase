// name spaces or code libarys
// .net frame work 
using System.Collections;
using System.Collections.Generic;
// MonoBehavior is from the Unity name space
using UnityEngine;
// : extends or inherits
// Monobehavior unity specific term allow the drag and drop of scripts or behaviors into game objects to control them. 
//MonoBehaviour comes with void Start() and void Update()
public class Player : MonoBehaviour
{
    // variable declorations 
    // serializedfiled exposes _speed to editor even though it is private
    [SerializeField]
    private float _speed = 3.5f;
    // Start is called before the first frame update
     
    void Start()
    {
        // take the current positon as the start of the game (0,0,0)
           transform.position = new Vector3(0, 0, 0);
         }

    // Update is called once per frame ) (about 60 frames per second)
    void Update()
    {
        //local  vars = to the keyboard input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
              // creating new Vector
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        // transform.Translate(new Vector3(1, 0, 0) * 5 * real time);
        transform.Translate(direction * _speed * Time.deltaTime);
        // if player position on y is greater than 0 , y pos =0

        if (transform.position.y>=0)
        {
            // set new position , Vector3 needs all 3 
             transform.position= new Vector3(transform.position.x,0,0);
        }


                 }
}
