using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// need this namespace for the scenemanager
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // by default isGameOver is false
    [SerializeField]
    private bool _isGameOver;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && _isGameOver==true)
        {
            // takes in int which is the scene load index or scene name
            SceneManager.LoadScene(0);// index O is "Game"
        }
     }
    // method to call game over from the UIManager script GameOverSequennce
    public void GameOver()
    {
        // set is game over to true 
        //Debug.Log("GameManager::GameOver() called");
        _isGameOver = true;
    }
}
