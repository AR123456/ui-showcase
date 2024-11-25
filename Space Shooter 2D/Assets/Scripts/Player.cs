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
    // variable declorations 
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
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
                // transform.Translate(new Vector3(1, 0, 0) * 5 * real time);
        // using speed var
        //transform.Translate(Vector3.right * horizontalInput * _speed *  Time.deltaTime );
        // transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);
        // optimized for one line of code 
        transform.Translate(direction * _speed * Time.deltaTime);
                 }
}
