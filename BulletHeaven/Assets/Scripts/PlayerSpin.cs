using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpin : MonoBehaviour
{
    public float speedRotate;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.K) || Input.GetKey("joystick button 2")) {
            transform.Rotate(Vector3.forward * speedRotate * Time.deltaTime);
            anim.enabled=true;
        }
        else
            anim.enabled=false;
    }
}
