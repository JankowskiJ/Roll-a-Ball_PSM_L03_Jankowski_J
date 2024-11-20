using UnityEngine;
using System;
public class MovementController : MonoBehaviour
{
    private Rigidbody player_Rigidbody;
    private float player_Thrust = 20f;
    private Vector3 direction;
    public event Action GroundTouchEvent;
    void Start()
    {
        player_Rigidbody = GetComponent<Rigidbody>();
        direction = new Vector3(0,0,0);
    }
    void Update()
    {
        MovementVector();
    }
    private void FixedUpdate()
    {
        MovementForce();
    }
    private void MovementVector()
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
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
            player_Thrust = 20f;
            GroundTouchEvent?.Invoke();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            player_Thrust = 5f;
        }
    }
    private void MovementForce()
    {
        player_Rigidbody.AddForce(direction.normalized * player_Thrust);
    }

}
