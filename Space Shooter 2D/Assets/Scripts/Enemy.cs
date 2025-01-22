using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;
    private Player _player;
    private Animator _anim;
    private AudioSource _audioSource;
    [SerializeField]
    // game object to store referenct to its prefab
    private GameObject _laserPrefab;
 
    void Start()
    {
        //define player cashed later used to update score 
        _player = GameObject.Find("Player").GetComponent<Player>();
        // get audio souce from emenmy 
        _audioSource = GetComponent<AudioSource>();
          if (_player ==null)
        {
            Debug.LogError("The Player is Null");
        }
        _anim = GetComponent<Animator>();
            if (_anim==null)
        {
            Debug.LogError("The animator is Null");
        }
        transform.position = new Vector3(0, 5.75f, 0);
    }
    // Update is called once per frame
    void Update()
    {
        // 4 meters per second
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
              if (transform.position.y <= -5f)
        {
            float randomX = Random.Range(-8f,8f);
            transform.position = new Vector3(randomX, 5.75f, 0);
       
        }
    }
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        //  damage Player (lives system) and then Destroy us (enemy) 
        if (other.tag=="Player")
        {  
           // set var in Player.cs use GetComponent to call it from here
           Player player = other.transform.GetComponent<Player>();
           if (player != null)
            {
            player.Damage();
            }
            _anim.SetTrigger("OnEnemyDeath");
            _speed = 0; // so explosion dosent damage player
             // play the explosion  before destroy 
            _audioSource.Play();
            //Destroy enemy but give the animation a sec to play first
            Destroy(this.gameObject,2.8f);
        
            }
          // if other tag is laser Destroy Laser then distroy us(enemy)
        if (other.tag =="Laser")
        {
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
            // play the explosion - before destroy 
            _audioSource.Play();
            // collision of object should no longer be active - destroy the collider component
            // any collider 2D that is on this object
            Destroy(GetComponent<Collider2D>());

            // Destroy enemy but give the animation a sec to play first
            Destroy(this.gameObject,2.8f);
        
        }

    }
 
 

}
