using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] points;
    [SerializeField]
    int maxScore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       points = GameObject.FindGameObjectsWithTag("Collectible"); 
       maxScore = points.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void NextLevel() 
    {

    }
}
