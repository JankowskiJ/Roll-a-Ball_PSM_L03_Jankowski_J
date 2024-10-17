using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(32,12,4)* Time.deltaTime);
    }
    public void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
    }
}
