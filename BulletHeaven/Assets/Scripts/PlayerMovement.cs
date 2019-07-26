using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Handles direction input as well as dashing.
public class PlayerMovement : MonoBehaviour {
    public float speed;
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private PlayerHealth healthObj;
    private Vector2 moveVelocity;
    private Vector2 moveInput;

    private bool canDash;
    private int direction;
    public float dashtime;
    public float startDashTime;
    public float dashSpeed;

    /// Time, in seconds, for dash cooldown
    public float timeBetweenDashes = 1f;
    // public GameObject dashEffect; REENABLE WHEN DASH EFFECT COMPLETED

    // Start is called before the first frame update
    void Start () {
        rb = GetComponent<Rigidbody2D> ();
        bc = GetComponent<BoxCollider2D> ();
        healthObj = GetComponent<PlayerHealth> ();
        dashtime = startDashTime;
        direction = 0;
        canDash = true;
    }

    // Update is called once per frame
    void Update () {

        // Dash input check
        if (Input.GetKey (KeyCode.Space) || Input.GetKey (KeyCode.JoystickButton4) || Input.GetKey (KeyCode.JoystickButton5)) { // Space, LeftBumper, RightBumper
            if (canDash) {
                if ((Mathf.Abs (Input.GetAxis ("Horizontal")) > Mathf.Abs (Input.GetAxis ("Vertical"))) && (Input.GetAxis ("Horizontal") < 0)) { //left
                    direction = 1;
                } else if ((Mathf.Abs (Input.GetAxis ("Horizontal")) > Mathf.Abs (Input.GetAxis ("Vertical"))) && (Input.GetAxis ("Horizontal") > 0)) { //right
                    direction = 2;
                } else if ((Mathf.Abs (Input.GetAxis ("Horizontal")) < Mathf.Abs (Input.GetAxis ("Vertical"))) && (Input.GetAxis ("Vertical") > 0)) { //up
                    direction = 3;
                } else if ((Mathf.Abs (Input.GetAxis ("Horizontal")) < Mathf.Abs (Input.GetAxis ("Vertical"))) && (Input.GetAxis ("Vertical") < 0)) { //down
                    direction = 4;
                }

                if (direction != 0)
                    StartCoroutine (Dash ());
            }
        }

        moveInput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

        moveVelocity = moveInput.normalized * speed;
        
        if(direction == 0)
            rb.MovePosition (rb.position + moveVelocity * Time.fixedDeltaTime);

    }

    /// Assumes that player can dash. Do checking in update()
    IEnumerator Dash () {

        canDash = false;

        healthObj.invincibility = true;

        switch (direction) {
            case 1:
                rb.velocity = Vector2.left * dashSpeed;
                break;
            case 2:
                rb.velocity = Vector2.right * dashSpeed;
                break;
            case 3:
                rb.velocity = Vector2.up * dashSpeed;
                break;
            case 4:
                rb.velocity = Vector2.down * dashSpeed;
                break;
        }

        yield return new WaitForSeconds (dashtime);

        direction = 0;
        dashtime = startDashTime;
        rb.velocity = Vector2.zero;
        healthObj.invincibility = false;
        yield return new WaitForSeconds (timeBetweenDashes);
        canDash = true;
    }
}