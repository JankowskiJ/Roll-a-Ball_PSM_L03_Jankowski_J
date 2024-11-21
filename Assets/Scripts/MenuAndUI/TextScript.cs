using UnityEngine;
using TMPro;
public class TextScript : MonoBehaviour
{
    private GameObject gameManager;
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManager.GetComponent<GameManager>().ScoreAddEvent += changeText;
    }
    private void changeText() 
    {
       gameObject.GetComponent<TMP_Text>().text = "Score: " + gameManager.GetComponent<GameManager>().score;
    }
}
