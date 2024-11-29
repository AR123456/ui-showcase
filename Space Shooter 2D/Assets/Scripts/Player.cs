// name spaces or code libarys
 
using System.Collections;
using System.Collections.Generic;
// MonoBehavior is from the Unity name space
using UnityEngine;
// : extends or inherits
// Monobehavior unity specific term allow the drag and drop of scripts or behaviors into game objects to control them. 
//MonoBehaviour comes with void Start() and void Update()
public class Player : MonoBehaviour
{
    // 
    // serializedfiled exposes _speed to editor even though it is private public vars are exposed there out of box
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.15f;
    [SerializeField]
    private float _nextFire = 0.0f;
    // Start is called before the first frame update
         void Start()
    {
        //positon as the start of the game (x,y,z)
           transform.position = new Vector3(0, 0, 0);
         }
        // Update is called once per frame ) (about 60 frames per second)
    void Update()
    {
      CalculateMovement();
        // when the space bar is pressed, fire laser if cooldown condition met
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextFire )
        {
            // spawn game object  
            // keep track of this fire for next one
            _nextFire = Time.time + _fireRate;
            Instantiate(_laserPrefab, transform.position + new Vector3(0,0.8f,0), Quaternion.identity);
           
        }
    }
// custom method resposible for all things movement related - call this from update 
void CalculateMovement()
    {
        //local vars = to the keyboard input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        // creating new Vector
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        // transform.Translate(new Vector3(1, 0, 0) * 5 * real time);
        transform.Translate(direction * _speed * Time.deltaTime);
        // using clamp for y 
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0),0);
        // x stop on let at -11 , on R if 11 reached reset postion to -11
        if (transform.position.x <= -11)
        {
            transform.position = new Vector3(11, transform.position.y, 0);
        }
        else if (transform.position.x >= 11)
        {
            transform.position = new Vector3(-11, transform.position.y, 0);
        }
    }
}
