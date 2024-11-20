using UnityEngine;

public class TrampolinePlayerController : MonoBehaviour
{
    public int TrampolineTouchCounter = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trampoline"))
        {
            TrampolineTouchCounter++;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            TrampolineTouchCounter = 0;
        }
    }
}
