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
    private Vector3 spawnPosBack;
    public float spawnDistance;
    private AudioSource BulletSource;
    private Quaternion targetRotation;
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
        spawnPosBack = transform.position - (facing*spawnDistance);
        Quaternion targetRotation = transform.transform.rotation;
        /*Debug.Log(facing+ " "+ transform.position +" "+ spawnPos);*/
        if(Input.GetKey(KeyCode.J) || Input.GetKey("joystick button 2"))
        {
            transform.Rotate(Vector3.forward * speedRotate * Time.deltaTime);
            if (Time.time > nextFire)
            {
                nextFire = Time.time + timeBtwnBullets;
                GameObject cloneF = Instantiate(bulletPrefab, spawnPos, transform.rotation) as GameObject;
                //GameObject cloneB = Instantiate(bulletPrefab, spawnPosBack,  targetRotation * Quaternion.Euler(0, 0, 180f)) as GameObject;
                //BulletSource.Play();
            }

        } else if(Input.GetKey(KeyCode.K) || Input.GetKey("joystick button 0"))
        {
            transform.Rotate(Vector3.forward * speedRotate * Time.deltaTime);
            if (Time.time > nextFire)
            {
                nextFire = Time.time + timeBtwnBullets;
                GameObject cloneF = Instantiate(bulletPrefab, spawnPos, transform.rotation) as GameObject;
                GameObject cloneB = Instantiate(bulletPrefab, spawnPosBack,  targetRotation * Quaternion.Euler(0, 0, 180f)) as GameObject;
                BulletSource.Play();
            }

        }
    }

    
}
