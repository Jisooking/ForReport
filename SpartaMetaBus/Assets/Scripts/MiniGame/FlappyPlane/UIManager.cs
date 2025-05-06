using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI startText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;

    private bool gameStarted = false;


    private void Awake()
    {
        Time.timeScale = 0.0f;
        startText.gameObject.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        if(restartText == null)
        {
            Debug.Log("restart text is null");
        }
        if(scoreText == null)
        {
            Debug.Log("score text is null");
        }
        restartText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!gameStarted && Input.anyKey)
        {
            startText.gameObject.SetActive(false);
            Time.timeScale = 1f;
            gameStarted = true; // 한 번 시작되면 더 이상 확인하지 않음
        }
    }
    public void ReturnMainScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }
    
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
    // Update is called once per frame
}
