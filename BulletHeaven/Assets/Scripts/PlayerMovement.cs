using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private Vector2 moveVelocity;
    private Vector2 moveInput;
    public float dashStrength;
    private float dashtime;
    private int direction;
    public float startDashTime;
    public float dashSpeed;
    private float dash;
    private float nextDash;
    public float timeBtwnDash;
    private bool dashDown;
    public GameObject dashEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        direction = 0;
        dashtime = startDashTime;
        dash = 1;
        nextDash = 0;
        dashDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        moveVelocity = moveInput.normalized * speed;
        /* if(Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown("joystick button 4") || Input.GetKeyDown("joystick button 5"))
            dashDown=true;
        else
            dashDown=false;
        if(!dashDown)*/

        rb.MovePosition(rb.position + moveVelocity * dash * Time.fixedDeltaTime);
        /*if(Input.GetKeyDown(KeyCode.LeftShift) || dashDown || Input.GetKeyDown("joystick button 4") || Input.GetKeyDown("joystick button 5"))
        {
            if (Time.time > nextDash)
            {
                dashDown = true;
                nextDash = Time.time + timeBtwnDash;
                dash = dashSpeed;
            }
            else
            {
                dashDown = false;
                dash = 1;
            }
        }*/
    }

    void FixedUpdate()
    {
        //if(!dash)
            /* if(dash > 1)
            {
                Instantiate(dashEffect, transform.position, Quaternion.identity);
                bc.enabled = false;
                rb.MovePosition(rb.position + moveVelocity * dash * Time.fixedDeltaTime);
                bc.enabled = true;
                Instantiate(dashEffect, transform.position, Quaternion.identity);
            }
            else
                rb.MovePosition(rb.position + moveVelocity * dash * Time.fixedDeltaTime);*/
            
        
    }

    
}























/*
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            dash = true;
            if (direction == 0){
                if (Input.GetKeyDown(KeyCode.A)){
                    direction = 1;
                } else if (Input.GetKeyDown(KeyCode.D)){
                    direction = 2;
                } else if (Input.GetKeyDown(KeyCode.W)){
                    direction = 3;
                } else if (Input.GetKeyDown(KeyCode.S)){
                    direction = 4;
                }

            } else {
                if(dashtime <= 0){
                    direction = 0;
                    dashtime = startDashTime;
                    rb.velocity = Vector2.zero;
                    dash = false;
                } else {
                    dashtime -= Time.deltaTime;

                    if(direction == 1){
                        rb.velocity = Vector2.left * dashSpeed;
                    } else if (direction == 2){
                        rb.velocity = Vector2.right * dashSpeed;
                    } else if (direction == 3){
                        rb.velocity = Vector2.up * dashSpeed;
                    } else if (direction == 4){
                        rb.velocity = Vector2.down * dashSpeed;
                    }
                }
            }
        }
        */

        /* void OnCollision2DEnter(Collision collision) 
 {
         if(collision.gameObject.name == "YourWallName")  // or if(gameObject.CompareTag("YourWallTag"))
         {
                     GetComponent<Rigidbody>().velocity = Vector3.zero;
         }
 }*/