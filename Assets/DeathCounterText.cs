using TMPro;
using UnityEngine;

public class DeathCounterText : MonoBehaviour
{
    private GameObject player;
    [SerializeField]
    private int deathCount;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<DeathController>().DeathEvent += changeText;
    }
    private void changeText()
    {
        deathCount++;
        gameObject.GetComponent<TMP_Text>().text =""+ deathCount;
    }
}
