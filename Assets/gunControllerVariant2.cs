using UnityEngine;

public class gunControllerVariant2 : gunController
{
    [SerializeField] private float waveFrequency = 2f;
    [SerializeField] private float waveAmplitude = 1f; 

    protected override void Shoot()
    {
        GameObject go = Instantiate(bullet, transform.position + direction, Quaternion.identity);
        SinusMovment movement = go.AddComponent<SinusMovment>();
        movement.SetParameters(direction, waveFrequency, waveAmplitude,randomNumber);
    }
}
