using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;
 
    private float _randNum = Random.Range(-3, 3);

    // Start is called before the first frame update
    void Start()
    {
        // define starting position of cube Y of 5.73 looks like top of screen
        transform.position = new Vector3(_randNum, 5.75f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // move down at rate of 4 meters per second 
        transform.Translate(Vector3.down * (Time.time/_speed));
        if (transform.position.y <=-15f)
        {
            transform.position = new Vector3(0, 5.75f, 0);
             
        }
       
        // when it moves down the full lentgth of the screen, re spawn it at the top with a new random x position - this saves the step of distroing it if it drops off screen
        // call bottom of screen -15 y 

    }
}
