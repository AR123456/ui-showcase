using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
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
    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if (player !=null)
            {
                 
              //   player._isTripleShotActive == true;
                Destroy(this.gameObject);
            }
        } 
    }

}
