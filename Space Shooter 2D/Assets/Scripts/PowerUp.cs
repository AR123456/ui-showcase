using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
     //ID for Powerups 0=tripleshot, 1=speed,2=Shields
    [SerializeField]
    private int powerupID;
    [SerializeField]
    private AudioClip _clip;
     // Update is called once per frame
    void Update()
    {
        // move down 3 meters per second 
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
       if (transform.position.y <= -4.5f)
        {
            Destroy(this.gameObject);
        }
    }
        private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            // method plays at position of powerup
              AudioSource.PlayClipAtPoint(_clip,transform.position);

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
            // destroy  power up 
            Destroy(this.gameObject);
        } 
    }

}
