using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // speed variable of 8 
    [SerializeField]
    private float _lzspeed = 8.0f;
        // Start is called before the first frame update
    void Start()
    {      
    }
        // Update is called once per frame
    void Update()
    {
        // laser behavior here - move up infinantly 
        // transform of laser
        transform.Translate(Vector3.up*_lzspeed*Time.deltaTime);
        // if the laser position of the y coordinate is >= 6.09 it should be removed from the game. 

        if (transform.position.y > 6.9f)
        {
            Debug.Log("dump trash");
           // Destroy(gameObject);
        }
    }
}
 