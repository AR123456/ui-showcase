using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _rotateSpeed = 19.0f;
  

    // Update is called once per frame
    void Update()
    {
        // pass in the axis to rotate
        transform.Rotate(Vector3.forward* _rotateSpeed * Time.deltaTime);
      }
    // check for Laser collission (trigger)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (other.tag == "Laser")
        {
            //trigger explosion animation 
            _anim.SetTrigger("OnLaserHitAsteroid");
            
        }
    }

    // instantiate explosion at postion of the astorid (us)
}
