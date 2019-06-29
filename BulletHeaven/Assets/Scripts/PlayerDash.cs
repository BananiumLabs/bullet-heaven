using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    private bool dash;
    private int direction;
    public float dashtime;
    public float startDashTime;
    public float dashSpeed;
    private Rigidbody2D rb;  
    private BoxCollider2D bc;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        dashtime = startDashTime;
        direction = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (direction == 0){
            if ( (Mathf.Abs( Input.GetAxis("Horizontal") ) > Mathf.Abs( Input.GetAxis("Vertical") )) && (Input.GetAxis("Horizontal") < 0) ){ //left
                direction = 1;
            } else if ( (Mathf.Abs( Input.GetAxis("Horizontal") ) > Mathf.Abs( Input.GetAxis("Vertical") )) && (Input.GetAxis("Horizontal") > 0) ){ //right
                direction = 2;
            } else if ( (Mathf.Abs( Input.GetAxis("Horizontal") ) < Mathf.Abs( Input.GetAxis("Vertical") )) && (Input.GetAxis("Vertical") > 0) ){ //up
                direction = 3;
            } else if ( (Mathf.Abs( Input.GetAxis("Horizontal") ) < Mathf.Abs( Input.GetAxis("Vertical") )) && (Input.GetAxis("Vertical") < 0) ){ //down
                direction = 4;
            }

        } else {
            if(dashtime <= 0){
                direction = 0;
                dashtime = startDashTime;
                rb.velocity = Vector2.zero;
                bc.enabled = true;
            } else {
                dashtime -= Time.deltaTime;
                
                if(direction == 1 && (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown("joystick button 4") || Input.GetKeyDown("joystick button 5"))){
                    bc.enabled = false;
                    rb.velocity = Vector2.left * dashSpeed;
                } else if (direction == 2 && (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown("joystick button 4") || Input.GetKeyDown("joystick button 5"))){
                    bc.enabled = false;
                    rb.velocity = Vector2.right * dashSpeed;
                } else if (direction == 3 && (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown("joystick button 4") || Input.GetKeyDown("joystick button 5"))){
                    bc.enabled = false;
                    rb.velocity = Vector2.up * dashSpeed;
                } else if (direction == 4 && (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown("joystick button 4") || Input.GetKeyDown("joystick button 5"))){
                    bc.enabled = false;
                    rb.velocity = Vector2.down * dashSpeed;
                }
            }
        }
    }
}
