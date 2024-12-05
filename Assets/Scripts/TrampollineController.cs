using UnityEngine;
using System;
using Unity.VisualScripting;

public class TrampollineController : MonoBehaviour
{
    private GameObject player, gameManager;
    private Component particle;
    private bool onTouch = false;
    private int counter;
    public int maxCounter = 5;
    private int jumpForceCombo;
    public event Action TrampolineTouchEvent,TrampolineNoTouchEvent;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManager.GetComponent<TrampolineManager>().TrampolineTouchCountEvent += jumpCalc;
        particle = gameObject.GetComponentInChildren<ParticleSystem>();
    }
    private void FixedUpdate()
    {
        if (onTouch)
        {
            player.GetComponent<Rigidbody>().AddForce(transform.up * jumpForceCombo , ForceMode.Impulse);
            onTouch = false;
        }
    }
    public void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player")) {
            onTouch = true;
            TrampolineTouchEvent?.Invoke();
            particle.GetComponent<ParticleSystem>().Play();
        }
    }
    public void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            onTouch = true;
            TrampolineNoTouchEvent?.Invoke();
            particle.GetComponent<ParticleSystem>().Pause();
        }
    }
    private void jumpCalc()
    {
        counter = gameManager.GetComponent<TrampolineManager>().TrampolineTouchCount;
        if (counter <= maxCounter)
        {
            jumpForceCombo = counter * 2;
        }
    }
}
