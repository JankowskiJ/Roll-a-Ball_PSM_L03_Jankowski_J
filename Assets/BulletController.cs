using UnityEngine;

public class BulletController : MonoBehaviour
{
    private void Start()
    {
        if(gameObject.name != "Bullet")
        {
            Invoke("DestroyOnTime", 6f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    private void DestroyOnTime()
    {
        Destroy(gameObject); 
    }
}
