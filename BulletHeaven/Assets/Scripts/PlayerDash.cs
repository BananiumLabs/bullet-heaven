using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour {
    private bool canDash;
    private int direction;
    public float dashtime;
    public float startDashTime;
    public float dashSpeed;

    /// Time, in seconds, for dash cooldown
    public float timeBetweenDashes = 1f;
    private Rigidbody2D rb;

    private PlayerHealth healthObj;
    // Start is called before the first frame update
    void Start () {
        rb = GetComponent<Rigidbody2D> ();
        healthObj = GetComponent<PlayerHealth> ();
        dashtime = startDashTime;
        direction = 0;
        canDash = true;
    }

    // Update is called once per frame
    void Update () {
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

        // if (dashing) {
        //     if (dashtime <= 0) {
        //         direction = 0;
        //         dashtime = startDashTime;
        //         rb.velocity = Vector2.zero;
        //         bc.enabled = true;
        //         dashing = false;
        //     } else {
        //         dashtime -= Time.deltaTime;

        //         if (direction == 1) {
        //             bc.enabled = false;
        //             rb.velocity = Vector2.left * dashSpeed;
        //         } else if (direction == 2) {
        //             bc.enabled = false;
        //             rb.velocity = Vector2.right * dashSpeed;
        //         } else if (direction == 3) {
        //             bc.enabled = false;
        //             rb.velocity = Vector2.up * dashSpeed;
        //         } else if (direction == 4) {
        //             bc.enabled = false;
        //             rb.velocity = Vector2.down * dashSpeed;
        //         }
        //     }
        // }

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