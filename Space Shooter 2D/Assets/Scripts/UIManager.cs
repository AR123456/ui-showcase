using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // need to update text score, need a handle to text component 
    // be sure to add UnityEngine.UI so Text class is avalbile 
    [SerializeField]
    private Text _scoreText;

    // Start is called before the first frame update
    void Start()
    {
        // assign text componet to handle
     // get this from the 
     // _scoreText.text = "Score: " + 0 ;
    }

    // method to call from player.cs
    public void UpdateScore(int playerScore) {

        _scoreText.text = "Score: " + playerScore.ToString();
    }
  
}
