using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    private Transform trans;
    public float timeBtwnBullets;
    private float nextFire;
    public GameObject bulletPrefab;
    public float speedRotate;
    private Vector3 facing;
    private Vector3 spawnPos;
    public float spawnDistance;
    private AudioSource BulletSource;
    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        BulletSource = GetComponent<AudioSource>();
        nextFire = 0;
    }

    // Update is called once per frame
    void Update()
    {
        facing = transform.up;
        spawnPos = transform.position + (facing*spawnDistance);
        /*Debug.Log(facing+ " "+ transform.position +" "+ spawnPos);*/
        if(Input.GetKey(KeyCode.J) || Input.GetKey("joystick button 2"))
        {
            transform.Rotate(Vector3.forward * speedRotate * Time.deltaTime);
            if (Time.time > nextFire)
            {
                nextFire = Time.time + timeBtwnBullets;
                GameObject clone = Instantiate(bulletPrefab, spawnPos, transform.rotation) as GameObject;
                BulletSource.Play();
            }

        }
    }

    
}
