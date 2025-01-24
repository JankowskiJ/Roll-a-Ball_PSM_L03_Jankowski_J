using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float destroyTime = 6f;
    private void Start()
    {
        if(gameObject.name != "Bullet")
        {
            Invoke("DestroyOnTime", destroyTime);
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
