using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {
    private int health, halos, previousHealth, previousHalos;
    public Text current, allTime, bounty, timer;
    public static float Score = 0, AllTimeScore = 0, EnemiesKilled = 0, Bounty = 1, TimeElapsed = 0;
    // Start is called before the first frame update
    void Start () {
        health = GameObject.Find ("Player").GetComponent<PlayerHealth> ().health;
        halos = GameObject.Find ("Player").GetComponent<PlayerHealth> ().halos;
        previousHealth = health;
        previousHalos = halos;
    }

    // Update is called once per frame
    void Update () {
        Bounty = Mathf.Floor (EnemiesKilled / 10f) + 1f;
        current.text = "CURRENT SCORE\n" + Score;
        allTime.text = "ALL-TIME RECORD\n" + ((Score > GetHighScore.highScore) ? Score : GetHighScore.highScore);
        bounty.text = "BOUNTY\n" + Bounty + "x";

        health = GameObject.Find ("Player").GetComponent<PlayerHealth> ().health;
        halos = GameObject.Find ("Player").GetComponent<PlayerHealth> ().halos;

        Debug.Log (Bounty + " and enemies " + EnemiesKilled);

        healthChecker ();
        haloChecker ();

        TimeElapsed += Time.deltaTime;

        string minutes = Mathf.Floor (TimeElapsed / 60).ToString ("00");
        string seconds = (TimeElapsed % 60).ToString ("00");
        timer.text = "TIME ELAPSED: " + minutes + ":" + seconds;
    }
    void healthChecker () {
        /*if(health == 0){
            GameObject.Find("
                        HealthCross (1)
                        ").SetActive(false);
            GameObject.Find("
                        HealthCross (2)
                        ").SetActive(false);
            GameObject.Find("
                        HealthCross (3)
                        ").SetActive(false);
        } else if (health == 1){
            //GameObject.Find("
                        HealthCross (1)
                        ").SetActive(true);
            GameObject.Find("
                        HealthCross (2)
                        ").SetActive(false);
            GameObject.Find("
                        HealthCross (3)
                        ").SetActive(false);
        } else if (health == 2){
            //GameObject.Find("
                        HealthCross (1)
                        ").SetActive(true);
            //GameObject.Find("
                        HealthCross (2)
                        ").SetActive(true);
            GameObject.Find("
                        HealthCross (3)
                        ").SetActive(false);
        } else if (health == 3){
            //GameObject.Find("
                        HealthCross (1)
                        ").SetActive(true);
            //GameObject.Find("
                        HealthCross (2)
                        ").SetActive(true);
            //GameObject.Find("
                        HealthCross (3)
                        ").SetActive(true);
        }*/

        if (health == 3 && previousHealth != health) {
            //haha nope
        } else if (health == 2 && previousHealth != health) {
            GameObject.Find ("HealthCross (3)").SetActive (false);
            previousHealth = health;
        } else if (health == 1 && previousHealth != health) {
            GameObject.Find ("HealthCross (2)").SetActive (false);
            previousHealth = health;
        } else if (health == 0 && previousHealth != health) {
            GameObject.Find ("HealthCross (1)").SetActive (false);
            previousHealth = health;
        }
    }
    void haloChecker () {
        /* if(halos == 0){
            GameObject.Find("
                        HaloImage (1)
                        ").SetActive(false);
            GameObject.Find("
                        HaloImage (2)
                        ").SetActive(false);
            GameObject.Find("
                        HaloImage (3)
                        ").SetActive(false);
        } else if (halos == 1){
            GameObject.Find("
                        HaloImage (1)
                        ").SetActive(true);
            GameObject.Find("
                        HaloImage (2)
                        ").SetActive(false);
            GameObject.Find("
                        HaloImage (3)
                        ").SetActive(false);
        } else if (halos == 2){
            GameObject.Find("
                        HaloImage (1)
                        ").SetActive(true);
            GameObject.Find("
                        HaloImage (2)
                        ").SetActive(true);
            GameObject.Find("
                        HaloImage (3)
                        ").SetActive(false);
        } else if (halos == 3){
            GameObject.Find("
                        HaloImage (1)
                        ").SetActive(true);
            GameObject.Find("
                        HaloImage (2)
                        ").SetActive(true);
            GameObject.Find("
                        HaloImage (3)
                        ").SetActive(true);
        }*/

        if (halos == 3 && previousHalos != halos) { } else if (halos == 2 && previousHalos != halos) {
            GameObject.Find ("HaloImage (3)").SetActive (false);
            previousHalos = halos;
        } else if (halos == 1 && previousHalos != halos) {
            GameObject.Find ("HaloImage (2)").SetActive (false);
            previousHalos = halos;
        } else if (halos == 0 && previousHalos != halos) {
            GameObject.Find ("HaloImage (1)").SetActive (false);
            previousHalos = halos;
        }
    }
}