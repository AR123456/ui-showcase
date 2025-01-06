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
            //trigger explosion animation 
  
        }
    }

    // instantiate explosion at postion of the astorid (us)
 
    // clean up after 3 sec 
  
}
