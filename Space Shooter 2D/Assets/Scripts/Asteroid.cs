using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _rotateSpeed = 19.0f;
     // creating and serialize to make visibel need to add from unity inspector
    [SerializeField]
    private GameObject _explosionPrefab;
    // get ref to spawnmanger to call StartSpawning
     private SpawnManager _spawnManager;
    private void Start()
    {
        // at the start get spawn manager
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
    }
    // Update is called once per frame
    void Update()
    {
        // pass in the axis to rotate
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

  
 
    // clean up after 3 sec 
  
}
