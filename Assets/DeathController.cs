using UnityEngine;
using System;
public class DeathController : MonoBehaviour
{
    public event Action DeathEvent;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lava"))
        {
            Death();
        }
    }
    private void Death()
    {
        DeathEvent?.Invoke();
    }
}
