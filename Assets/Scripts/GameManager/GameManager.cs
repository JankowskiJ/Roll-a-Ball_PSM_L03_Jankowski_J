using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] points;
    private GameObject player;
    [SerializeField]
    private int maxScore, sceneNumber;
    public int score=0;
    public event Action WinEvent;
    public event Action ScoreAddEvent;

    void Start()
    {
        points = GameObject.FindGameObjectsWithTag("Collectible");
        player = GameObject.FindGameObjectWithTag("Player");
        maxScore = points.Length;
        player.GetComponent<ScoreController>().PickupEvent += ScoreAdd;
        player.GetComponent<ScoreController>().PickupEvent += NextLevel;

        sceneNumber = SceneManager.GetActiveScene().buildIndex;
    }
    private void NextLevel() 
    {
        if (score == maxScore)
        {
           WinEvent?.Invoke();
           Invoke("LevelLoad", 5.0f);
        }
    }
    private void ScoreAdd()
    {
        score++;
        ScoreAddEvent?.Invoke();
    }
    private void LevelLoad()
    {
        SceneManager.LoadScene(sceneNumber+1, LoadSceneMode.Single);
    }
}
