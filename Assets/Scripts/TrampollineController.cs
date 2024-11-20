using UnityEngine;
using System;
public class TrampollineController : MonoBehaviour
{
    private GameObject player, gameManager;
    private bool onTouch = false;
    private int counter;
    public int maxCounter = 5;
    private int jumpForceCombo;
    public event Action TrampolineEvent;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManager.GetComponent<TrampolineManager>().TrampolineTouchCountEvent += jumpCalc;
    }
    // Update is called once per frame
    void Update() {

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
            TrampolineEvent?.Invoke();
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
