using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // by default isGameOver is false
    [SerializeField]
    private bool _isGameOver;
    // method to call the game over method of the game manager 
    public void GameOver()
    {
        // set is game over to true 
        _isGameOver = true;
    }
    // user input functionality happens here - void update method for user input 
}
