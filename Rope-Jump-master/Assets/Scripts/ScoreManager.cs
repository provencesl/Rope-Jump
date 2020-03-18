using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    const string HIGHSCORE_PREF_KEY = "highscore";

    public Text highScoreTxt;
    public Text scoreTxt;
    public Text bottomText;

    private int score;
    private int highScore;

    // Use this for initialization
    void Start () {
        score = 0;
        scoreTxt.text = score.ToString();
        
        highScore = PlayerPrefs.GetInt(HIGHSCORE_PREF_KEY,0);
        highScoreTxt.text = "Highscore:" + highScore.ToString();
    }

    public void IncreaseScore() {
        score++;
        scoreTxt.text = score.ToString();

        if (score > highScore) {
            UpdateHighscore();
        }
    }

    public void UpdateHighscore() {
        highScore = score;
        highScoreTxt.text = "Highscore: " + highScore.ToString();
    }

    public void isHighscore() {
        if (score == highScore) {
            bottomText.text = "Game Over\nNew Highscore!!";
            Debug.Log("wohoo");
            PlayerPrefs.SetInt(HIGHSCORE_PREF_KEY, highScore);
        }
        else
            bottomText.text = "Game Over";
    }

    public void PlayAgain() {
        bottomText.text = "Tap to Jump";
    }

    public int GetScore() {
        return score;
    }
}
