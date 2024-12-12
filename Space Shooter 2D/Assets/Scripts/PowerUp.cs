using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    // need to identify which power up using intiger system- give ids
    //ID for Powerups 0=tripleshot, 1=speed,2=Shields


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move down at rate of 3 meters per second - use deltatime, not time 
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        // bottom 0f screen -5f
        if (transform.position.y <= -4.5f)
        {
            Destroy(this.gameObject);
        }
    }
    // detect collision with player
    // only to be collectable by the player- tags
    // on collect destroy
    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if (player !=null)
            {
                // in the communication to the player need to not hard code to the triple shot
                // but look to what powerup contacted the player
                // which power up am I representing when spawned 
                player.TripleShotActive();          
                     }
            // destroy the power up 
            Destroy(this.gameObject);
        } 
    }

}
