using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
public class TextScript : MonoBehaviour
{
    private GameObject player,gameManager;
    private int score;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        player.GetComponent<ScoreController>().PickupEvent += changeText;
    }
    private void changeText() 
    {
        score++;
       gameObject.GetComponent<TMP_Text>().text = "" + score;
    }
}
