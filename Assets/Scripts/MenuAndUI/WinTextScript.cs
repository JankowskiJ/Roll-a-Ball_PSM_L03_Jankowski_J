using TMPro;
using UnityEngine;

public class WinTextScript : MonoBehaviour
{
    private GameObject gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManager.GetComponent<GameManager>().WinEvent += WinTextChange;
    }
    private void WinTextChange()
    {
        gameObject.GetComponent<TMP_Text>().text = "Wygra³eœ";
    }
}
