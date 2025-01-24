using UnityEngine;
public abstract class gunController : MonoBehaviour
{
    [SerializeField]
    protected float bulletSpeed = 1f;
    protected GameObject bullet;
    protected float randomNumber;
    protected Vector3 direction;
    protected virtual void Start()
    {
        bullet = GameObject.FindGameObjectWithTag("Bullet");
        direction = transform.forward * -1;
    }
    protected abstract void Shoot();
    protected virtual void OnDisable()
    {
        CancelInvoke("Shoot");
    }
    protected virtual void OnEnable()
    {
        InvokeRepeating("Shoot", 0f, bulletSpeed);
        randomNumber = Random.Range(0.0f, 1.0f);
    }
}
