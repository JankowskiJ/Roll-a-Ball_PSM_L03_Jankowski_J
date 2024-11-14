using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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
    Vector3 direction, jumpVector;

    // Start is called before the first frame update
    void Start()
    {
        player_Rigidbody = GetComponent<Rigidbody>();
        direction = new Vector3(0,0,0);
        jumpVector = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {

        //timer = +Time.deltaTime;
        //keyW = Input.GetKey(KeyCode.W);
        //keyS = Input.GetKey(KeyCode.S);
        //keyD = Input.GetKey(KeyCode.D);
        //keyA = Input.GetKey(KeyCode.A);
        //keySpace = Input.GetKeyDown(KeyCode.Space);
        //if (timer >= 2)
        //{
        //    timer = 0;
        //}
        direction = Vector3.zero;
        jumpVector = Vector3.zero;
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpVector += Vector3.up;
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
        player_Rigidbody.AddForce(jumpVector.normalized * jump_Force,ForceMode.Impulse);
        /*
        if (keyW) 
        {
            player_Rigidbody.AddForce(Vector3.forward * player_Thrust);
        }
        if (keyA)
        {
            player_Rigidbody.AddForce(Vector3.left * player_Thrust);
        }
        if (keyD)
        {
            player_Rigidbody.AddForce(Vector3.right * player_Thrust);
        }
        if (keyS)
        {
            player_Rigidbody.AddForce(Vector3.back * player_Thrust);
        }
        if (keySpace)
        {
            Debug.Log("test");
            player_Rigidbody.AddForce(0, jump_Force, 0,ForceMode.Impulse);
        }
        */
    }
    public void OnTriggerEnter(Collider other)
    {
        score += 1;
        Debug.Log("Zdoby³eœ punkt! masz teraz: "+score+" punkty");
        scoreText.text = "Score: " + score;
        if(score == 7) 
        {
            Debug.Log("Zdoby³eœ wszystkie punkty");
            winText.text = "Wygra³eœ";
            isWin = true;
        }
    }
}
