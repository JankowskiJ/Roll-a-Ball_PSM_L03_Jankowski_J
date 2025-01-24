using UnityEngine;

public class SinusMovment : MonoBehaviour
{
    private Vector3 direction;
    private float waveFrequency;
    private float waveAmplitude;
    private float time;
    private float randomNumber;
    public void SetParameters(Vector3 d, float wF, float wA, float radom)
    {
        direction = d.normalized;
        waveFrequency = wF;
        waveAmplitude = wA;
        randomNumber = radom;
    }
    void Update()
    {
        time += Time.deltaTime;
        Vector3 forwardMovement = direction * waveAmplitude/0.2f * Time.deltaTime;
        Vector3 waveMovement = new Vector3(Mathf.Sin(time * waveFrequency) * (waveAmplitude+randomNumber) * 0.2f, 0, 0);
        transform.position += forwardMovement+waveMovement;
    }
}
