using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    // need to identify which power up using intiger system- give ids
    //ID for Powerups 0=tripleshot, 1=speed,2=Shields
    [SerializeField]
    // initializing to set in inspector - will be avalible in prefabs
    private int powerupID;
    // ref to powerup sound - serialize to apply in inspector
    [SerializeField]
    private AudioClip _clip;
 

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
              //ID for Powerups 0=tripleshot, 1=speed,2=Shields
                switch (powerupID)
                {
                    case 0:
                        player.TripleShotActive();
                            break;
                    case 1:
                        player.SpeedBoostActive();
                        break;
                    case 2:
                        player.SheildActive();
                        break;
                    default:
                        Debug.Log("This is the default case");
                        break;
                }

            }
            // destroy the power up 
            Destroy(this.gameObject);
        } 
    }

}
