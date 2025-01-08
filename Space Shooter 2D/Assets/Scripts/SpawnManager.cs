using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // var to store object to spawn in the Instantiate method in the IEnumerator
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    // make this the powerup array- 
    private GameObject[] powerups;
    private bool _stopSpawning = false;
    //calling StartSpawing()from asteroid
 public void StartSpawning()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupRoutine());
    }
    // spawn game objects every 5 seconds (coroutine)
    // create a coroutine of type IEnumerator 
 IEnumerator SpawnEnemyRoutine()
    {
        // add a delay to let asteroid explode before spawning starts 
        yield return new WaitForSeconds(3.0f);

        // in while loop only loop if player is alive
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
  
    IEnumerator SpawnPowerupRoutine() {
        // add a delay to let asteroid explode before spawning starts 
        yield return new WaitForSeconds(3.0f);
        // every 3-7 seconds spawn in a power up 
        // in while loop only loop if player is alive
        while (_stopSpawning == false)
        {
            // define random postion to spawn to
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7f, 0);
            // define random power up to past to the instatiate from powerup array
            int randomPowerUp = Random.Range(0, 3);
            Instantiate(powerups[randomPowerUp], posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3, 8));
        }
    }    
    

    public void onPlayerDeath()
    {
        _stopSpawning = true;
    }


}
