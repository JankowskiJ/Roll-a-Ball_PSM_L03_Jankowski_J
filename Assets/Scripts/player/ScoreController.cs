using UnityEngine;
using System;
public class ScoreController : MonoBehaviour
{
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
        PickupEvent?.Invoke();
    }
}
