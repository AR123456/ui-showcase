using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;
    // ref/handle to player component
    private Player _player;
    // ref/andle to enemys animator component
    private Animator _anim;
    // ref to explosion AudioSource class
    private AudioSource _audioSource;

     // Start is called before the first frame update
    void Start()
    {
        //define player cashed later used to update score 
        _player = GameObject.Find("Player").GetComponent<Player>();
        // get audio souce from emenmy 
        _audioSource = GetComponent<AudioSource>();
        // do a null check on player
        if (_player ==null)
        {
            Debug.LogError("The Player is Null");
        }
        // assign enemy animator component
        _anim = GetComponent<Animator>();
        // null check as best practice
        if (_anim==null)
        {
            Debug.LogError("The animator is Null");
        }

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
           // damage player start at 3, decrement with each hit from laser 
           // set var in Player.cs use GetComponent to call it from here
           Player player = other.transform.GetComponent<Player>();
            // check for null first
            if (player != null)
            {
            player.Damage();
            }
            // trigger explosion animation - pass in its name 
            _anim.SetTrigger("OnEnemyDeath");
            _speed = 0; // so explosion dosent damage player
                        // play the explosion 
            _audioSource.Play();
            //Destroy enemy but give the animation a sec to play first
            Destroy(this.gameObject,2.8f);
        
            }
          // if other tag is laser Destroy Laser then distroy us(enemy)
        if (other.tag =="Laser")
        {
            //  Debug.Log("Laser collision ");
            // Destory laser
            Destroy(other.gameObject);
            // call players method for adding score
            if (_player!=null)
            {
                // the param passed in goes to player.cs
                _player.AddScore(10);
            }
            // trigger explosion animation pass in its name 
            _anim.SetTrigger("OnEnemyDeath");
            _speed = 0;
            // play the explosion 
            _audioSource.Play();
            // Destroy enemy but give the animation a sec to play first
            Destroy(this.gameObject,2.8f);
        
        }

    }


}
