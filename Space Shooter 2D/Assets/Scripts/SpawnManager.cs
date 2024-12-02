using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
 
    // Start is called before the first frame update
    void Start()
    {
        SpawnRoutine();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // spawn game objects every 5 seconds (coroutine)
    // create a coroutine of type IEnumerator 
  public IEnumerator SpawnRoutine()
    {
      int i = 5;
        while (i <5)
        {
            yield return GetComponent<Enemy>();
        }
        // infinte game loop  while  it will run as long as a contdition is due( beware the infinate loop) 
            // instantiate object, need ref to it. - the enemy prefab
                // yeild events  - wait for 5 seconds
    }
}
