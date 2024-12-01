using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;
 
 

    // Start is called before the first frame update
    void Start()
    {
        // define starting position of cube Y of 5.73 looks like top of screen
        transform.position = new Vector3(0, 5.75f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // move down at rate of 4 meters per second - use deltatime, not time 
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
          // bottom 0f screen -5f
        if (transform.position.y <= -5f)
        {
            // rand numb between 8 and - 8 - make it a float
            float randomX = Random.Range(-8f,8f);
            transform.position = new Vector3(randomX, 5.75f, 0);
        }
    }
    // detect collison 
    private void OnTriggerEnter(Collider other)
    {
        //who hit who? 
        // Debug.Log("Hit: " + other.transform.name);
        // if other is Player
        //  damage Player (lives system) and then Destroy us (enemy) 
        if (other.gameObject.tag=="Player")
        {
            //  Debug.Log("Player collision ");
            Destroy(gameObject);
        
        }
        // if other is laser
        // Destroy Laser and then distroy us (enemy)
        if (other.gameObject.tag =="Laser")
        {
            //  Debug.Log("Laser collision ");
            Destroy(gameObject);
        }

    }


}
