using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class TextScript : MonoBehaviour
{
    private GameObject textScore,player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        player.GetComponent<MovementController>().
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void changeText() 
    {
        textScore.text = "Score: " + player.score;
    }
}
