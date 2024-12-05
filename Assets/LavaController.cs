using UnityEngine;
using System;
public class LavaController : MonoBehaviour
{
    private Vector3 startPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = new Vector3(5,0.5f,1);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Transform>().position = startPosition;
            collision.gameObject.GetComponent<Rigidbody>().Sleep();
        }
    }
}
