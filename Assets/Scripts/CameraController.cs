using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    Vector3 cameraPosition;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cameraPosition =  player.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position - cameraPosition ;
    }
}
