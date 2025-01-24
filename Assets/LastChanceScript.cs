using UnityEngine;

public class LastChanceScript : MonoBehaviour
{
    private float timer=0;
    private bool cooldown = false;
    [SerializeField]
    GameObject zone;
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && !cooldown)
        {
          zone.SetActive(true);
          Invoke("zoneOFF", 0.5f);
          cooldown = true;
        }
        if (cooldown) {
            timer += Time.deltaTime;
            if (timer > 30) {
                cooldown = false;
            }
        }
    }
    private void zoneOFF()
    {
        zone.SetActive(false);
    }
}
