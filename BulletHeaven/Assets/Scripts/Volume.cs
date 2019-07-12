using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour {

    AudioSource[] audioSources;
    public AudioSource musicSource;

    public Button[] musicButtons;
    public Button[] sfxButtons;

    static int currMusicLevel = -1, currSfxLevel = -1;

    // Start is called before the first frame update
    void Start () {
        audioSources = Object.FindObjectsOfType<AudioSource> ();
        // print(audioSources);

        if(currMusicLevel < 0) {
            OnClickMusic(3);
            OnClickSfx(3);
        }
        else {
            currMusicLevel--;
            currSfxLevel--;
            OnClickMusic(currMusicLevel + 1);
            OnClickSfx(currSfxLevel + 1);
        }
        musicSource.volume = 0.2f * currMusicLevel;
        foreach (AudioSource audio in audioSources) {
            if (audio.gameObject.name != "Music Source") {
                audio.volume = 0.2f * currSfxLevel;
            }
        }
    }

    // Update is called once per frame
    void Update () {

    }

    /// ButtonNo is 1-5.
    public void OnClickMusic (int buttonNo) {
        // Mute
        if (currMusicLevel == buttonNo) {
            for (int i = 0; i < musicButtons.Length; i++) {
                musicButtons[i].GetComponentInChildren<Text> ().text = "_";
            }
            currMusicLevel = 0;
            musicSource.volume = 0;
        } else {
            for (int i = 0; i < buttonNo; i++) {
                musicButtons[i].GetComponentInChildren<Text> ().text = "0";
            }
            for (int i = buttonNo; i < musicButtons.Length; i++) {
                musicButtons[i].GetComponentInChildren<Text> ().text = "_";
            }
            musicSource.volume = 0.2f * buttonNo;
            currMusicLevel = buttonNo;
        }
    }

    public void OnClickSfx (int buttonNo) {
        // Mute
        if (currSfxLevel == buttonNo) {
            for (int i = 0; i < sfxButtons.Length; i++) {
                sfxButtons[i].GetComponentInChildren<Text> ().text = "_";
            }
            currSfxLevel = 0;
            foreach (AudioSource audio in audioSources) {
                if (audio.gameObject.name != "Music Source") {
                    audio.volume = 0;
                }
            }
        } else {
            for (int i = 0; i < buttonNo; i++) {
                sfxButtons[i].GetComponentInChildren<Text> ().text = "0";
            }
            for (int i = buttonNo; i < sfxButtons.Length; i++) {
                sfxButtons[i].GetComponentInChildren<Text> ().text = "_";
            }
            foreach (AudioSource audio in audioSources) {
                if (audio.gameObject.name != "Music Source") {
                    audio.volume = 0.2f * buttonNo;
                }
            }
            currSfxLevel = buttonNo;
        }
    }
}