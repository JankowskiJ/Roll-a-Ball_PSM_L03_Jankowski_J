using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private AudioSource m_AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(32,12,4)* Time.deltaTime);
    }
    public void OnTriggerEnter(Collider other)
    {
        m_AudioSource.Play();
        Invoke("deActiveObject", 2.0f);
        GetComponent<MeshRenderer>().enabled = false;
    }
    private void deActiveObject() 
    {
        gameObject.SetActive(false);
    }
}
