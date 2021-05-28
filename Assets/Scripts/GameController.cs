using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public int totalScore;
    public Text scoreText;

    public GameObject gameOver;

    public static GameController instance;

    void Start()
    {
        LoadScore();
        UpdateScoreText();
        instance = this;

        SaveGame();

        //Scene scene = SceneManager.GetActiveScene();
        //Debug.Log("Active Scene is '" + scene.name + "'.");

    }

    public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString();
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

    public void RestartGame(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
        LoadScore();
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("score", totalScore);
    }

    private void SaveGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        PlayerPrefs.SetString("lvlname", scene.name);
    }

    public void LoadScore()
    {
        totalScore = PlayerPrefs.GetInt("score");
    }

    public void NewGame()
    {
        totalScore = 0;
        SaveScore();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("lvlname"));
    }
}
