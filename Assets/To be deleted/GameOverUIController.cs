using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUIController : MonoBehaviour {

    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text highScoreText;

    private string scoreTextString;
    private string highScoreTextString;

    private float highScore;

    // Use this for initialization
    void Start () {
        scoreTextString = scoreText.text;
        highScoreTextString = highScoreText.text;

        scoreText.text = scoreTextString + PlayerScore.Score.ToString();

        highScore = PlayerPrefs.GetFloat("highscore");
        
        if (PlayerScore.Score > highScore)
        {
            highScore = PlayerScore.Score;
            PlayerPrefs.SetFloat("highscore", highScore);
            PlayerPrefs.Save();
        }

        highScoreText.text = highScoreTextString + highScore.ToString();
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene(1);
    }
}
