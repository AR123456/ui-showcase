using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// bring in the SceneManagement name space
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
 // method to call with button click - public so unity can see it
 public void LoadGame() {
        // load game scene - build settings position 2 in array index 1
        SceneManager.LoadScene(1); 
    }
}
