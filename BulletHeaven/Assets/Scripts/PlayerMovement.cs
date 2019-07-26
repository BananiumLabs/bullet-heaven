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
        canDash = true;
    }

    // Update is called once per frame
    void Update () {

        moveInput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));


        // Dash input check
        if (Input.GetKey (KeyCode.Space) || Input.GetKey (KeyCode.JoystickButton4) || Input.GetKey (KeyCode.JoystickButton5)) { // Space, LeftBumper, RightBumper
            if (canDash) {
                StartCoroutine (Dash ());
            }
        }

        moveVelocity = moveInput.normalized * speed;
        
        if(dashtime == startDashTime) // Not currently dashing
            rb.MovePosition (rb.position + moveVelocity * Time.fixedDeltaTime);

    }

    /// Assumes that player can dash. Do checking in update()
    IEnumerator Dash () {

        canDash = false;

        healthObj.invincibility = true;

        rb.velocity = moveInput * dashSpeed;

        yield return new WaitForSeconds (dashtime);

        dashtime = startDashTime;
        rb.velocity = Vector2.zero;
        healthObj.invincibility = false;
        yield return new WaitForSeconds (timeBetweenDashes);
        canDash = true;
    }
}