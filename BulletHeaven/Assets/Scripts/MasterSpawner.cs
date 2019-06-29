using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterSpawner : MonoBehaviour
{
    private float nextSpawn, rand1, rand2, lastTime;
    private int x, i;
    public float spawnRate;

    // Start is called before the first frame update
    void Start()
    {
        nextSpawn = 3;
        lastTime = 0;
        x = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            /* nextSpawn = Time.time + spawnRate;
            if(Time.time < 20.0f) {
                for(int i = 3; i > 0; i--) {
                    GameObject.Find("EnemySpawner (" + Random.Range(1,12) +")").GetComponent<SpawnScript>().Spawn(Random.Range(1,3));
                }
            } else if(Time.time < 40.0f) {
                for(int i = 4; i > 0; i--) {
                    GameObject.Find("EnemySpawner (" + Random.Range(1,12) +")").GetComponent<SpawnScript>().Spawn(Random.Range(1,3));
                }
            } else if(Time.time < 60.0f) {
                for(int i = 5; i > 0; i--) {
                    GameObject.Find("EnemySpawner (" + Random.Range(1,12) +")").GetComponent<SpawnScript>().Spawn(Random.Range(1,3));
                }
            } else if(Time.time < 80.0f) {
                for(int i = 6; i > 0; i--) {
                    GameObject.Find("EnemySpawner (" + Random.Range(1,12) +")").GetComponent<SpawnScript>().Spawn(Random.Range(1,3));
                }
            }*/

            nextSpawn = Time.time + spawnRate;
            i = x;
            while(i > 0) {
                GameObject.Find("EnemySpawner (" + Random.Range(1,13) +")").GetComponent<SpawnScript>().Spawn(Random.Range(1,5));
                i--;
            }
            if((Time.time-lastTime)/20 >= 1) {
                lastTime = Time.time;
                x++;
                Debug.Log(Time.time);
            }


        }
        //GameObject.Find("EnemySpawner (1)").GetComponent<SpawnScript>().Spawn(2);
        //Debug.Log(Time.time);
    }
}
