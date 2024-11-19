using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class TextScript : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<ScoreController>().PickupEvent += changeText;
    }
    private void changeText() 
    {
       gameObject.GetComponent<TMP_Text>().text = "Score: " + player.GetComponent<ScoreController>().score;
    }
}
