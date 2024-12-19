using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;
    // create reference to the player or handle to the component
    private Player _player;

     // Start is called before the first frame update
    void Start()
    {
        // this defines player one time then it gets cashed and can later be used to update score 
        _player = GameObject.Find("Player").GetComponent<Player>();
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
            // call players method for adding score
            if (_player!=null)
            {
                _player.AddScore();
            }
            // Destroy enemy
            Destroy(this.gameObject);
        }

    }


}
