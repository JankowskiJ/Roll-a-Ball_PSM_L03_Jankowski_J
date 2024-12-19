using UnityEngine;
using System;
using System.Collections;
public class DeathController : MonoBehaviour
{
    public event Action DeathEvent;
    [SerializeField]
    private bool isInvincible;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lava")&& !isInvincible)
        {
            isInvincible = true;
            Death();
            Invoke("DeathFrames", 0.2f);
        }
        if (collision.gameObject.CompareTag("Bullet")&& !isInvincible)
        {
            isInvincible = true;
            Death();
            Invoke("DeathFrames", 0.2f);
        }
        
    }
    private void Death()
    {
            DeathEvent?.Invoke();
    }
    private void DeathFrames()
    {
        isInvincible = false;
    }
}
