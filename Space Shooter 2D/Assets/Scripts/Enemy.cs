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
    // private void OnTriggerEnter(Collider other) - change to 2D 
    private void OnTriggerEnter2D(Collider2D other)
    {
        //  damage Player (lives system) and then Destroy us (enemy) 
        if (other.tag=="Player")
        {  
           // damage player sart with 3, decrement with each hit from laser 
           // set this variable in the Player script - use GetComponent to call it from here
           Player player = other.transform.GetComponent<Player>();
            // check for null first
            if (player != null)
            {
            player.Damage();
            }
            // destory enemy
            Destroy(this.gameObject);
            }
        // if other is laser
        // Destroy Laser and then distroy us (enemy)
        if (other.tag =="Laser")
        {
            //  Debug.Log("Laser collision ");
            // Destory laser
            Destroy(other.gameObject);
            // access player data (call players method for adding score)  and add 10 to score
            Player player = other.transform.GetComponent<Player>();
            player._score +=10;
            player._scoreText.text = _score;
            // Destroy enemy
            Destroy(this.gameObject);
        }

    }


}
