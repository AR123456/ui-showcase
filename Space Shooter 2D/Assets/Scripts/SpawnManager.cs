using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // variable to store the object we want to spawn in the Instantiate method in the IEnumerator
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    private bool _stopSpawning = false;

        // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }
        // Update is called once per frame
    void Update()
    {
        
    }
    // spawn game objects every 5 seconds (coroutine)
    // create a coroutine of type IEnumerator 
 IEnumerator SpawnRoutine()
    {
        // in while loop only loop if player is alive

         //   while (true)
            while (_stopSpawning == false)
        {
       //var to randsomize position of _enemyPrefab 
           Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7f, 0);
       // instantiate object, put in game object variable 
          GameObject newEnemy=  Instantiate(_enemyPrefab, posToSpawn,Quaternion.identity);
            // parent object of the game object we just instantiated getting assigned to the transform
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);    
    
        }

       
    }

    public void onPlayerDeath()
    {
        _stopSpawning = true;
    }


}
