using UnityEngine;
public class gunController : MonoBehaviour
{
    private GameObject bullet;
    private Vector3 direction;
    [SerializeField]
    private float bulletSpeed = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bullet = GameObject.FindGameObjectWithTag("Bullet");
        direction = new Vector3(0, 0, -1);
        InvokeRepeating("Shoot", 0f, bulletSpeed);
    }
    private void Shoot()
    {
        GameObject go = Instantiate(bullet, transform.position+direction, Quaternion.identity);
        go.GetComponent<Rigidbody>().AddForce(direction * 15, ForceMode.Impulse);

    }
}
