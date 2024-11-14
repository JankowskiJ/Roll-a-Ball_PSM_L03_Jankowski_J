using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class MovementController : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text winText;
    Rigidbody player_Rigidbody;
    public float player_Thrust = 20f;
    public float jump_Force = 0.5f;
    public int score;
    private bool isWin;
    private float timer=0;
    //public event Action pickupEvent;
    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        player_Rigidbody = GetComponent<Rigidbody>();
        direction = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction -= Vector3.forward;
        }
        if (isWin)
        {
            timer += Time.deltaTime;
            if(timer >= 5) {
                SceneManager.LoadScene(2, LoadSceneMode.Single);
            }
        }
    }

    private void FixedUpdate()
    {
        player_Rigidbody.AddForce(direction.normalized * player_Thrust);
    }
    public void OnTriggerEnter(Collider other)
    {
        GainPoint();
    }
    private void GainPointXD() 
    {
        score += 1;
        Debug.Log("Zdoby³eœ punkt! masz teraz: " + score + " punkty");
        scoreText.text = "Score: " + score;
        if (score == 7)
        {
            Debug.Log("Zdoby³eœ wszystkie punkty");
            winText.text = "Wygra³eœ";
            isWin = true;
        }
    }
    private void GainPoint() 
    {
        score += 1;
        pickupEvent();
        Debug.Log("Zdoby³eœ punkt! masz teraz: " + score + " punkty");
    }
}
