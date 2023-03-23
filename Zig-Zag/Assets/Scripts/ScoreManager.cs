using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private int score;
   
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        PlayerPrefs.SetInt("score", score);
    }
        
    public void IncrementScore(int addScore)
    {
        score += addScore;
        UiManager.instance.scoreText2.text = "Score: " + score.ToString();
        PlayerPrefs.SetInt("score", score);

        if(PlayerPrefs.HasKey("highScore"))
        {
            if(score > PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", score);
            }

        }
        else
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }
}
