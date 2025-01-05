using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _rotateSpeed = 19.0f;
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        // pass in the axis to rotate
        transform.Rotate(Vector3.forward* _rotateSpeed * Time.deltaTime);
      }
    // check for Laser colllission (trigger)
    // instantiate explosion at postion of the astorid (us)
}
