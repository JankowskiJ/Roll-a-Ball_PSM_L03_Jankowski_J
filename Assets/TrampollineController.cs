using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrampollineController : MonoBehaviour
{
    public GameObject player;
    bool onTouch = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (onTouch)
        {
            player.GetComponent<Rigidbody>().AddForce(transform.up * 10, ForceMode.Impulse);
            Debug.Log("skok");
            onTouch = false;
        }
    }
    public void OnTriggerEnter(Collider collider)
    {
        if(collider.GameObject()==player) {
            onTouch = true;
        }
    }
}
