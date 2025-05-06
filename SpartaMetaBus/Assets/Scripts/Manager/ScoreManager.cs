using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public GameObject scoreTitle;
    public TextMeshProUGUI scoreText;
    public int bestScore = 0;
    public TextMeshProUGUI isSucess;

    public bool isFirstLoad = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        UpdateScoreUI();
    }

    public void Update()
    {
        if (scoreTitle != null)
        {
            if (Input.anyKey)
            {
                scoreTitle.SetActive(false);
            }
        }
    }
    public void UpdateScoreUI()
    {
        scoreText.text = bestScore.ToString();
    }

    public void IsSucess()
    {
        if (bestScore < 10 && bestScore > 0)
        {
            isSucess.text = "Fail..";
        }
        else if (bestScore > 10)
        {
            isSucess.text = "Sucess!!";
        }
        else
        {
            isSucess = null;
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (isFirstLoad)
        {
            isFirstLoad = false;
            return;
        }

        if (scene.name == "MainScene")
            ScoreManager.instance.scoreTitle.SetActive(true);
    }
}
