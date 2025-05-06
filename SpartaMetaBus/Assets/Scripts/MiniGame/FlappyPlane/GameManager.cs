using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;
    public static GameManager Instance { get { return gameManager; } }

    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<UIManager>();
    }

    private int currentScore = 0;
    UIManager uiManager;

    public UIManager UIManager
    {
        get
        {
            return uiManager;
        }
    }

    public void Start()
    {
        uiManager.UpdateScore(0);
    }
    public void GameOver()
    {
        Debug.Log("Game Over");              
        ScoreManager.instance.bestScore = currentScore;
        ScoreManager.instance.UpdateScoreUI();
        ScoreManager.instance.IsSucess();
        uiManager.ReturnMainScene();
    }

    //public void RestartGame()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}

    public void AddScore(int score)
    {
        currentScore += score;
        uiManager.UpdateScore(currentScore);
    }
}
