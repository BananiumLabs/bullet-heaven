using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperBulletSpawn : MonoBehaviour
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
    private Quaternion targetRotation;
    private RaycastHit2D hit;
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
        Quaternion targetRotation = transform.transform.rotation;
        /*Debug.Log(facing+ " "+ transform.position +" "+ spawnPos);*/
        if(Input.GetKey(KeyCode.J) || Input.GetKey("joystick button 2"))
        {
            transform.Rotate(Vector3.forward * speedRotate * Time.deltaTime);
            if (Time.time > nextFire)
            {
                hit = Physics2D.Raycast(spawnPos, facing, 100);
                if(hit.collider != null)
                {
                    if(hit.collider.tag.Equals("Enemy"))
                    {
                        nextFire = Time.time + timeBtwnBullets;
                        GameObject cloneF = Instantiate(bulletPrefab, spawnPos, transform.rotation) as GameObject;
                    }
                }
            }

        } else if(Input.GetKey(KeyCode.J) || Input.GetKey("joystick button 2"))
        {
            transform.Rotate(Vector3.forward * speedRotate * Time.deltaTime);
            if (Time.time > nextFire)
            {
                nextFire = Time.time + timeBtwnBullets;
                GameObject cloneF = Instantiate(bulletPrefab, spawnPos, transform.rotation) as GameObject;
                BulletSource.Play();
            }

        }
    }

    
}
