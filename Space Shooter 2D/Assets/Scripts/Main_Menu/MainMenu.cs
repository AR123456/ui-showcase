using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// bring in the SceneManagement name space
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
 public void LoadGame() {
        // load game scene - array index 1
        SceneManager.LoadScene(1); 
    }
}
