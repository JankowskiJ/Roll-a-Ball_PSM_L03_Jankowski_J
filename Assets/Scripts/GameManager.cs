using UnityEditor.VersionControl;
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
    public event Action WinEvent;
    void Start()
    {
        points = GameObject.FindGameObjectsWithTag("Collectible");
        player = GameObject.FindGameObjectWithTag("Player");
        maxScore = points.Length;
        player.GetComponent<ScoreController>().PickupEvent += NextLevel;
        sceneNumber = SceneManager.GetActiveScene().buildIndex;
    }
    private void NextLevel() 
    {
        if (player.GetComponent<ScoreController>().score == maxScore)
        {
           WinEvent?.Invoke();
           Invoke("LevelLoad", 5.0f);
        }
    }
    private void LevelLoad()
    {
        SceneManager.LoadScene(sceneNumber+1, LoadSceneMode.Single);
    }
}
