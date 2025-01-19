// name spaces or code libarys
 using System.Collections;
using System.Collections.Generic;
// MonoBehavior is from the Unity name space
using UnityEngine;
// Monobehavior unity specific allows drag and drop of scripts or behaviors into game objects 
//MonoBehaviour comes with void Start() and void Update()
public class Player : MonoBehaviour
{
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
    // UIManger in the cashe - put it in void Start() to find it
    private UIManager _uiManager;
    [SerializeField]
    private AudioClip _laserSoundClip;
    [SerializeField]
     private AudioSource _audioSource;
  
    // Start is called before the first frame update
    void Start()
    {
         transform.position = new Vector3(0, 0, 0);
        // load at start 
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        // find the UIManager traverse Player into canvas 
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _audioSource = GetComponent<AudioSource>();

        if (_spawnManager==null)
        {
            Debug.LogError("The Spawn Manager is Null");
        }
  
        if (_uiManager==null)
        {
            Debug.LogError("The UI manager is null ");
        }
   
        if (_audioSource==null)
        {
            Debug.LogError("AudioSource on the player is null");
        }
        else
        {
                _audioSource.clip = _laserSoundClip;
       
        }
 
    }
    // Update is called once per frame (about 60 frames per second)
    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
        }
    }

    void FireLaser()
    {
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

        _audioSource.Play();
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
          if (_isShieldActive == true)
        {
            _isShieldActive = false;
             _shieldVisualizer.SetActive(false);
            return;
        }

       _lives--;
   
        if(_lives == 2)
        {
            _leftEngine.SetActive(true);
          
        }
    
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

    public void SpeedBoostActive()
    {
        _isSpeedBoostActive = true;

        _speed *= _speedMultiplier;
        StartCoroutine(SpeedBoostPowerDownRoutine());
    }

    IEnumerator SpeedBoostPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        _isSpeedBoostActive = false;
        // put speed back to its original pre powerup level
        _speed /= _speedMultiplier;
    }

 
    public void SheildActive()
    {
        _isShieldActive = true;
    
        _shieldVisualizer.SetActive(true);
     }
    
  
    public void AddScore(int points)
    {
        _score += points;
        //update UI with score dont use getcomponet here its too expensive
        // getting handle to UI manager out of cashe, call method from UIManger.cs
        _uiManager.UpdateScore(_score);
    }


}