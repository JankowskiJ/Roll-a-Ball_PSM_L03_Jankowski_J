using UnityEngine;
using System;
using Unity.VisualScripting;
using static UnityEngine.ParticleSystem;

public class TrampollineController : MonoBehaviour
{
    private GameObject player, gameManager;
    private ParticleSystem particle;
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
        if (onTouch && !player.GetComponent<MovementController>().isDead)
        {
            player.GetComponent<Rigidbody>().AddForce(transform.up * jumpForceCombo , ForceMode.Impulse);
            onTouch = false;
        }
        else if (onTouch && player.GetComponent<MovementController>().isDead)
        {
            onTouch = false;
        }
    }
    public void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player")) {
            onTouch = true;
            TrampolineTouchEvent?.Invoke();
            particle.transform.position = new Vector3(player.transform.position.x, particle.transform.position.y, player.transform.position.z);
            particle.Play();
            GetComponent<AudioSource>().Play();
        }
    }
    public void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            onTouch = true;
            TrampolineNoTouchEvent?.Invoke();
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
