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
    [SerializeField]
    private Text _gameOverText;
  
    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "Score: " + 0 ;
        // at start of game no game over text
        _gameOverText.gameObject.SetActive(false);
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
        // when calling this funtion from player js are already checking lives to add if statement to turn on game over 
        if (currentLives==0)
        {
                     _gameOverText.gameObject.SetActive(true);
            // coroutine with the while loop
           StartCoroutine(GameOverFlickerRoutine());
        }
    }
 
   IEnumerator GameOverFlickerRoutine()
    {
        while (true)
        {
            _gameOverText.text = "Game Over";
            yield return new WaitForSeconds(0.5f);
            _gameOverText.text = "";
            yield return new WaitForSeconds(0.5f);
        }  
    }
}
