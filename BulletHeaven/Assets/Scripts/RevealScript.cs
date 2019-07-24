using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealScript : MonoBehaviour
{
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = GameObject.Find("Player").transform.position;
        transform.rotation = new Quaternion(0f,0f,0f, 1);
        StartCoroutine(Die());
        //transform.localScale = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.localScale += new Vector3(1, 1, 1); // increase the X scale by 1.
    }   


    IEnumerator Die()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
    

}
