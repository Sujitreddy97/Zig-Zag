using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    public GameObject titlePanel;
    public GameObject gameOverPanel;
    public GameObject tapStart;
    public TMP_Text highScore1;
    public TMP_Text highScore2;
    public TMP_Text scoreText;
    public TMP_Text scoreText2;
    public GameObject screenScore;
    private AudioSource restartSound;
    public AudioClip tapSound;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        highScore1.text ="High Score: " + PlayerPrefs.GetInt("highScore").ToString();
        restartSound = GetComponent<AudioSource>();
    }
    public void GameStart()
    {
        Camera.main.GetComponent<AudioSource>().Play();
        tapStart.SetActive(false);
        titlePanel.GetComponent<Animator>().Play("PanelUp");
        screenScore.SetActive(true);
       
    }

    public void GameOver()
    {
        Camera.main.GetComponent<AudioSource>().Stop();
        scoreText.text ="Score: " + PlayerPrefs.GetInt("score").ToString();
        highScore2.text ="High Score: " + PlayerPrefs.GetInt("highScore").ToString();
        gameOverPanel.SetActive(true);
        screenScore.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);

        restartSound.PlayOneShot(tapSound, 0.5f);
    }

   
}
