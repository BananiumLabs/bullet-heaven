using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// Attach to sprite that you want to fade in and out
public class FadeEffect : MonoBehaviour {

    private Text txt;

    void Start () {
        txt = GetComponent<Text> ();
        StartCoroutine (FadeRoutine (0.02f, txt));
    }

    public IEnumerator FadeRoutine (float t, Text txt) {
        while (true) {

            txt.color = new Color (txt.color.r, txt.color.g, txt.color.b, 0);

            while (txt.color.a < 1.0f) {
                txt.color = new Color (txt.color.r, txt.color.g, txt.color.b, txt.color.a + (t));
                yield return new WaitForSeconds (0.01f);
            }

            while (txt.color.a > 0.0f) {
                txt.color = new Color (txt.color.r, txt.color.g, txt.color.b, txt.color.a - (t));
                yield return new WaitForSeconds (0.01f);
            }

        }
    }
}