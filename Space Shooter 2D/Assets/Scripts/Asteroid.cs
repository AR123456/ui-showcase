using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _rotateSpeed = 19.0f;
        [SerializeField]
   private bool _isExplosionActive=false;
    [SerializeField]
    private GameObject _laserPrefab;
    // Update is called once per frame
    void Update()
    {
        // pass in the axis to rotate
        transform.Rotate(Vector3.forward* _rotateSpeed * Time.deltaTime);
      }
    // check for Laser collission (trigger)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_laserPrefab!=null)
        {
            //trigger explosion animation 
           ExplosionActive();
            
        }
    }

    // instantiate explosion at postion of the astorid (us)
     public void ExplosionActive(){
     _isExplosionActive=true;
        StartCoroutine(OnLaserHitAsteroidPowerDownRoutine());
      }
    // clean up after 3 sec 
      IEnumerator OnLaserHitAsteroidPowerDownRoutine(){
      yield return new WaitForSeconds(3.0f);
        _isExplosionActive = false;
      }
}
