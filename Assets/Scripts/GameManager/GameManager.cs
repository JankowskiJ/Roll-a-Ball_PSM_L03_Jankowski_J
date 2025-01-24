using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] points;
    private GameObject player, finishLine, winText;
    [SerializeField]
    private int maxScore, sceneNumber;
    public int score = 0;

    private void Start()
    {

        points = GameObject.FindGameObjectsWithTag("Collectible");
        player = GameObject.FindGameObjectWithTag("Player");
        finishLine = GameObject.FindGameObjectWithTag("FinishLine");
        winText = GameObject.FindGameObjectWithTag("WinText");

        maxScore = points.Length;
        if (finishLine != null)
            finishLine.GetComponent<finishLineScript>().FinishLineEvent += NextLevelFinishLine;
        if (player != null)
        {
            player.GetComponent<ScoreController>().PickupEvent += ScoreAdd;
            player.GetComponent<ScoreController>().PickupEvent += NextLevelPoints;
            player.GetComponent<DeathController>().DeathEvent += NextLevelDeath;
        }
        sceneNumber = SceneManager.GetActiveScene().buildIndex;
    }
    private void NextLevelPoints()
    {
        if (sceneNumber == 1 && score == maxScore)
        {
            winText.GetComponent<TMP_Text>().text = "Za chwilê przejdziesz na nastêpny poziom";
            Invoke("LevelLoad", 5.0f);
        }
    }
    private void NextLevelFinishLine()
    {
        winText.GetComponent<TMP_Text>().text = "Za chwilê przejdziesz na nastêpny poziom";
        Invoke("LevelLoad", 5.0f);
    }
    private void NextLevelDeath()
    {
        if(sceneNumber == 3)
        {
            winText.GetComponent<TMP_Text>().text = "Zgin¹³eœ";
            Invoke("LevelLoad", 3.0f);
        }
    }

    private void ScoreAdd()
    {
        score++;
    }
    private void LevelLoad()
    {
        SceneManager.LoadScene(sceneNumber + 1, LoadSceneMode.Single);
    }
}
