using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class DataScript : MonoBehaviour
{
   private GameObject player;
   public int totalPoints, totalDeaths;
   private static DataScript instance = null;
    private bool endReached = false;
    public static DataScript Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null && !endReached)
        {
            player.GetComponent<ScoreController>().PickupEvent += ScoreAdd;
            player.GetComponent<DeathController>().DeathEvent += DeathAdd;
        }
        if(SceneManager.GetActiveScene().buildIndex == 4)
        {
            endReached = true;
        }
    }
    private void ScoreAdd()
    {
        totalPoints++;
    }
    private void DeathAdd() {
        totalDeaths++;
    } 
}
