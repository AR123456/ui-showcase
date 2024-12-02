using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // variable to store the object we want to spawn in the Instantiate method in the IEnumerator
    [SerializeField]
    private GameObject _enemyPrefab;

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
        // iterater for the while loop 
        int i = 1;
 

        // infinte game loop  while  it will run as long as a contdition is due( beware the infinate loop) 
    
        while (i<5)
        {
       //var to randsomize position of _enemyPrefab 
           Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7f, 0);
       // instantiate object, need ref to it. - the enemy prefab - put ref to it above start 
            Instantiate(_enemyPrefab, posToSpawn,Quaternion.identity);
            yield return new WaitForSeconds(5.0f);    
            i ++;
        }

       
    }




}
