using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//  UnityEngine.UI so Text class is avalbile 
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // a handle to text component 
   [SerializeField]
    private Text _scoreText;
    // handle lives display game oject image componet
    [SerializeField]
    private Image _LivesImg;
    // handle to the lives sprites
    [SerializeField]
    private Sprite[] _liveSprites;
    // text component for game over 
    // Start is called before the first frame update
    void Start()
    {
        // assign text componet to handle
     // get this from the 
     _scoreText.text = "Score: " + 0 ;
    }

    // method to call from player.cs
    public void UpdateScore(int playerScore) {

        _scoreText.text = "Score: " + playerScore.ToString();
    }
    // system to update lives - call from player.cs 
    public void UpdateLives(int currentLives)
    {
        // display img sprite based on currentlives index
     
        _LivesImg.sprite = _liveSprites[currentLives];
    }
    // method call in player.cs when lives <1
}
