using UnityEngine;
using System;
public class ScoreController : MonoBehaviour
{
    public int score;
    public event Action PickupEvent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            GainPoint();
        }
    }
    private void GainPoint()
    {
        score += 1;
        PickupEvent?.Invoke();
        Debug.Log("Zdoby³eœ punkt! masz teraz: " + score + " punkty");
    }
}
