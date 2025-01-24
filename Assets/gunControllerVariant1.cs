using UnityEngine;

public class gunControllerVariant1 : gunController
{
    protected override void Shoot()
    {
        GameObject go = Instantiate(bullet, transform.position + direction, Quaternion.identity);
        go.GetComponent<Rigidbody>().AddForce(direction * 15, ForceMode.Impulse);
    }
}
