// name spaces or code libarys
 using System.Collections;
using System.Collections.Generic;
// MonoBehavior is from the Unity name space
using UnityEngine;
// Monobehavior unity specific term allow the drag and drop of scripts or behaviors into game objects to control them. 
//MonoBehaviour comes with void Start() and void Update()
public class Player : MonoBehaviour
{
    // serializedfiled exposes private, public vars are exposed there out of box
    [SerializeField]
    private float _speed = 3.5f;
    private float _speedMultiplier = 2;
    [SerializeField]
    private GameObject _laserPrefab;
    // game object to store power up
   [SerializeField]
    private GameObject _tripleShotPrefab;
    [SerializeField]
    private float _fireRate = 0.15f;
    private float _canFire = -1f;
    [SerializeField]
    private int _lives = 3;
    // communicate with Spawn Manager
    private SpawnManager _spawnManager;
    private bool _isTripleShotActive = false;
    private bool _isSpeedBoostActive = false;
    private bool _isShieldActive = false;
    [SerializeField]
    private GameObject _shieldVisualizer;
    // get ref to r and l engine game objects
    [SerializeField]
    private GameObject _rightEngine, _leftEngine;
    [SerializeField]
    private int _score;
    // declare var for handle to coponent UIManger in the cashe - put it in void Start() to find it
    private UIManager _uiManager;
    // var to store audio file
    [SerializeField]
    private AudioClip _laserSoundClip;
    // audio source component off of the player -with code void start()
     private AudioSource _audioSource;
 

    // Start is called before the first frame update
    void Start()
    {
        //positon as the start of the game (x,y,z)
        transform.position = new Vector3(0, 0, 0);
        // getting the spawnmanager 
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        // find the UIManager traverse Player into canvas 
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        // assign audio source to the laser sound - already on the object so dont need to find the game object 
        _audioSource = GetComponent<AudioSource>();

        // have _spawnManager.onPlayerDeath now so do a null check and then can use it 
        if (_spawnManager==null)
        {
            Debug.LogError("The Spawn Manager is Null");
        }
        // null check for ui manager 
        if (_uiManager==null)
        {
            Debug.LogError("The UI manager is null ");
        }
        // null check on audio 
        if (_audioSource==null)
        {
            Debug.LogError("AudioSource on the player is null");
        }
        else
        {
            //.clip is a getter or a setter- here asigning clip
            _audioSource.clip = _laserSoundClip;
       
        }
 
    }
    // Update is called once per frame (about 60 frames per second)
    void Update()
    {
        CalculateMovement();
        // when the space bar is pressed, fire laser if cooldown condition met
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
        }
    }
    // custom method resposible for all things movement related - call this from update 
    void FireLaser()
    {
        // spawn game object  
        // keep track of this fire for next one
        _canFire = Time.time + _fireRate;
        if (_isTripleShotActive == true)
        {
            Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.05f, 0), Quaternion.identity);
        }
        // play audio clip from scirpt  - use Play() method 
 
    }
    void CalculateMovement()
    {
        //local vars = to the keyboard input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        // transform.Translate(new Vector3(1, 0, 0) * 5 * real time);
         transform.Translate(direction * _speed * Time.deltaTime);
                 
        // using clamp for y 
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);
        // x stop on let at -11 , on R if 11 reached reset postion to -11
        if (transform.position.x <= -11)
        {
            transform.position = new Vector3(11, transform.position.y, 0);
        }
        else if (transform.position.x >= 11)
        {
            transform.position = new Vector3(-11, transform.position.y, 0);
        }
    }
    public void Damage()
    {
        // if sheilds is active no damage no life lost
        if (_isShieldActive == true)
        {
            _isShieldActive = false;
            // turn off the sheilds visualizer 
            _shieldVisualizer.SetActive(false);
            return;
        }
      // damage trait here take damage, removing live
       _lives--;
        // enable right engine smoke
        if(_lives == 2)
        {
            _leftEngine.SetActive(true);
          
        }
        //  enable left engine smoke
        else if(_lives == 1)
        {
            _rightEngine.SetActive(true);
        }
        //change the sprite to reflect lives
        _uiManager.UpdateLives(_lives);
      if (_lives < 1)
        {
            // tell SpawnManager.cs to stop spawning 
            _spawnManager.onPlayerDeath();
             Destroy(this.gameObject);
        }
    }
    // method to control powerup reference this in that script
    public void TripleShotActive()
    {
        // tripleShotAcitve becomes true 
        _isTripleShotActive = true;
        // start the powerdonw conroutine for triple shot
        StartCoroutine(TripleShotPowerDownRoutine());
    }
      IEnumerator TripleShotPowerDownRoutine()
    {
                yield return new WaitForSeconds(5.0f);
        _isTripleShotActive = false;
     }
    // method to control speed powerup, reference this in powerup script 
    public void SpeedBoostActive()
    {
        _isSpeedBoostActive = true;
        // reset speed to -speed * _speedMultiplier
        _speed *= _speedMultiplier;
        StartCoroutine(SpeedBoostPowerDownRoutine());
    }
    // method to handle speed powerdown, make it inactive 
    IEnumerator SpeedBoostPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        _isSpeedBoostActive = false;
        // put speed back to its original pre powerup level
        _speed /= _speedMultiplier;
    }

    // Sheild acitve script to set to true and start coroutine, 
    public void SheildActive()
    {
        _isShieldActive = true;
        // enable the visualizer 
        _shieldVisualizer.SetActive(true);
     }
    
    // paramiterpoint value from enemy when enemy shot by laser
    public void AddScore(int points)
    {
        _score += points;
        //update UI with score dont use getcomponet here its too expensive
        // getting handle to UI manager out of cashe, call method from UIManger.cs
        _uiManager.UpdateScore(_score);
    }


}