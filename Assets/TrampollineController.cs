using System.Collections;
using System.Collections.Generic;
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
            player.GetComponent<Rigidbody>().AddForce(player.transform.up * 20f);
            onTouch = false;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        Debug.Log(player.name);
        if (other.name == player.name)
        {
            onTouch = true;
        }
    }
}
