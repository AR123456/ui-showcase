using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _rotateSpeed = 19.0f;
    [SerializeField]
    private GameObject _explosionPrefab;
    private SpawnManager _spawnManager;
    private void Start()
    {
        // get spawn manager
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
    }
    // Update is called once per frame
    void Update()
    {
        // axis to rotate
        transform.Rotate(Vector3.forward* _rotateSpeed * Time.deltaTime);
      }
    // check for Laser collission (trigger)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
           // instantiate explosion at postion of the astorid (us)
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            // destroy the laser
            Destroy(other.gameObject);
            // tell spawmn manager to run its StartSpawning method
           _spawnManager.StartSpawning();
            // destroy the asteroid- pass in delay
            Destroy(this.gameObject, 0.25f);
                     }
    }

  
}
