using UnityEngine;
using System;

public class finishLineScript : MonoBehaviour
{
    public event Action FinishLineEvent;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
            SendEvent();
        }
    }
    private void SendEvent()
    {
        FinishLineEvent?.Invoke();
    }
}
