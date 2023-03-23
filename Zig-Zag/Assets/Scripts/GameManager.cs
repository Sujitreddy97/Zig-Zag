using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public bool gameOver;


    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

    void Start()
    {
        gameOver = false;
    }
    public void GameStart()
    {
        UiManager.instance.GameStart();

        GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawner>().StartSpawningPlatform();
    }
    public void GameOver()
    {
        UiManager.instance.GameOver();
        gameOver = true;
       
    }


}
