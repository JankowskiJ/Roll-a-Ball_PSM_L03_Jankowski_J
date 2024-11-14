using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrampollineController : MonoBehaviour
{
    public GameObject player;
    bool onTouch = false;
    int counter;
    int jumpForceCombo;
    public float timer = 0f;
    float resetTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        timer += Time.deltaTime;
        if (timer >= resetTime)
        {
            counter = 0;
            jumpForceCombo = 0;
            timer = 0f;
        }
    }
    private void FixedUpdate()
    {
        if (onTouch)
        {
            player.GetComponent<Rigidbody>().AddForce(transform.up * jumpForceCombo , ForceMode.Impulse);
            Debug.Log("skok");
            onTouch = false;
        }
    }
    public void OnTriggerEnter(Collider collider)
    {
        if(collider.GameObject()==player) {
            onTouch = true;
            counter++;
            jumpForceCombo = counter * 2;
            timer = 0f;
        }
        else if (collider.CompareTag("Ground"))
        {
            jumpForceCombo = 0;
            timer = 0f;
        }
    }
}
