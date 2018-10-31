using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    [SerializeField]
    private Image overlay;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Button pauseButton;
    [SerializeField]
    private Text pauseText;
    [SerializeField]
    private Button resumeButton;
    [SerializeField]
    private Text gameOverText;
    [SerializeField]
    private Text retryText;
    [SerializeField]
    private Text highScoreText;
    [SerializeField]
    private Text retryButton;
    [SerializeField]
    private Text coinsText;

    private string scoreTextString;
    private string highScoreTextString;
    private string coinsTextString;

    // Use this for initialization
    void Start () {

        scoreTextString = scoreText.text;
        highScoreTextString = highScoreText.text;
        coinsTextString = coinsText.text;
        coinsText.text = coinsTextString + 0;

        overlay.gameObject.SetActive(false);
        pauseText.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);

        gameOverText.gameObject.SetActive(false);
        retryText.gameObject.SetActive(false);
        highScoreText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetScoreText(string text)
    {
        scoreText.text = scoreTextString + text;
    }

    public void SetCoinsText(string text)
    {
        coinsText.text = coinsTextString + text;
    }

    public void Pause()
    {
        AudioListener.pause = true;
        Time.timeScale = 0;

        pauseButton.gameObject.SetActive(false);
        overlay.gameObject.SetActive(true);
        pauseText.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(true);
    }

    public void Resume()
    {
        AudioListener.pause = false;
        Time.timeScale = 1;

        pauseButton.gameObject.SetActive(true);
        overlay.gameObject.SetActive(false);
        pauseText.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);
    }

    public void GameOver(float score)
    {
        pauseButton.gameObject.SetActive(false);
        overlay.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        retryText.gameObject.SetActive(true);
        highScoreText.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);

        SetHighScore(score);
    }

    private void SetHighScore(float score)
    {
        float highScore = PlayerPrefs.GetFloat("highscore");

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("highscore", highScore);
            PlayerPrefs.Save();
        }

        highScoreText.text = highScoreTextString + highScore.ToString();
    }

    public void Retry()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
