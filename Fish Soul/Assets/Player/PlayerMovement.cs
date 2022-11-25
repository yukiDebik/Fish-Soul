using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /*
    public float speed = 4f;
    private Vector2 direction;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }
    */

    private Rigidbody2D rb;
    public float baseSpeed = 4f;
    public float sprint = 9f;
    private float currentSpeed;
    private Vector2 direction;
    //private Vector2 movement = new Vector2(0f, 0f);
 
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }
 
    void Update ()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = sprint;
        }
        else
        {
            currentSpeed = baseSpeed;
        }
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

    }
 
    void FixedUpdate ()
    {
        //rb.MovePosition(rb.position + direction * currentSpeed * Time.fixedDeltaTime);
        //rb.MovePosition(rb.position + direction * baseSpeed * currentSpeed * Time.fixedDeltaTime);
    }
}
