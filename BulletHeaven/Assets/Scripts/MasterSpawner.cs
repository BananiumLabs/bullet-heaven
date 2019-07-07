using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MasterSpawner : MonoBehaviour {
    public float defaultSpawnRate;

    public enum Enemies { Vorpal, Shell, Lurker, Wraith };

 // Start is called before the first frame update
 void Start () {
 StartCoroutine (MasterWaveController ());
    }

    /// Defines all of the waves!!!
    IEnumerator MasterWaveController () {

        StartCoroutine (SendWave (new List<int> () { 3 }, delay : 1f));
        yield return new WaitForSeconds (defaultSpawnRate);
        StartCoroutine (SendWave (new List<int> () { 5 }, delay : 0.5f));
        yield return new WaitForSeconds (defaultSpawnRate);
        StartCoroutine (SendWave (new List<int> () { 5 }, delay : 0f));
        yield return new WaitForSeconds (defaultSpawnRate);
        StartCoroutine (SendWave (new List<int> () { 2, 2 }, delay : 1f));
        yield return new WaitForSeconds (defaultSpawnRate);
        StartCoroutine (SendWave (new List<int> () { 0, 8 }, delay : 1f));
        yield return new WaitForSeconds (defaultSpawnRate);
        StartCoroutine (SendWave (new List<int> () { 5, 5 }, delay : 0.5f));
        yield return new WaitForSeconds (defaultSpawnRate);
        StartCoroutine (SendWave (new List<int> () { 1, 1, 5 }, delay : 0f));
        yield return new WaitForSeconds (defaultSpawnRate);
        StartCoroutine (SendWave (new List<int> () { 15 }, delay : 0.25f));
        yield return new WaitForSeconds (defaultSpawnRate);
        StartCoroutine (SendWave (new List<int> () { 5, 5, 5 }, delay : 0.5f));
        yield return new WaitForSeconds (defaultSpawnRate);
        StartCoroutine (SendWave (new List<int> () { 5, 5, 5 }, delay : 0f));
        yield return new WaitForSeconds (defaultSpawnRate);
        StartCoroutine (SendWave (new List<int> () { 0, 0, 0, 3 }, delay : 1f));
        yield return new WaitForSeconds (defaultSpawnRate);
        StartCoroutine (SendWave (new List<int> () { 3, 0, 0, 3 }, delay : 1f));
        yield return new WaitForSeconds (defaultSpawnRate);
        StartCoroutine (SendWave (new List<int> () { 0, 1, 2, 3 }, delay : 1f));
        yield return new WaitForSeconds (defaultSpawnRate);
        StartCoroutine (SendWave (new List<int> () { 3, 3, 3, 3 }, delay : 1f));
        yield return new WaitForSeconds (defaultSpawnRate);

        // Randomly generated waves when the predefined ones run out
        int randomWaveCount = 4;
        List<int> randomEnemies;
        while (true) {
            randomEnemies = new List<int> ();

            for (int i = 0; i < Enemies.GetValues (typeof (Enemies)).Cast<int> ().Max (); i++) {
                randomEnemies.Add (Random.Range (1, randomWaveCount * 2));
                StartCoroutine (SendWave (randomEnemies, delay : 0.5f));
            }

            randomWaveCount++;
            yield return new WaitForSeconds (defaultSpawnRate);
        }
    }

    /// Sends a single wave of enemies at the player.
    /// Enemies list: 
    ///   Each index corresponds to the value defined by the enum Enemies (e.g. Vorpals are 0 index and Lurkers are 2).
    ///   Enemies after the last nonzero value do not have to be defined. (e.g. if you only want to spawn Shells, use [0,1] rather than [0,1,0,0....])
    /// Special Parameters:
    ///   delay (float): how much time to wait in between sending each individual enemy. Default: 0
    /// 
    IEnumerator SendWave (List<int> enemies, float delay = 0f) {

        List<int> nonZeroIndices;

        do {
            nonZeroIndices = new List<int> ();
            for (int i = 0; i < enemies.Count; i++) {
                if (enemies[i] > 0)
                    nonZeroIndices.Add (i);
            }

            int randomEnemyToSpawn = nonZeroIndices[Random.Range (0, nonZeroIndices.Count)];

            print ("Sending " + randomEnemyToSpawn);
            GameObject.Find ("EnemySpawner (" + Random.Range (1, 13) + ")").GetComponent<SpawnScript> ().Spawn (randomEnemyToSpawn);
            enemies[randomEnemyToSpawn]--;

            yield return new WaitForSeconds (delay);
        } while ((nonZeroIndices.Count > 0));

        yield return null;
    }
}