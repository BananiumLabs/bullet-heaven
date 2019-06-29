using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    // Start is called before the first frame update

    public Canvas pauseMenu;

    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown (KeyCode.JoystickButton7)) {
            ToggleMenu();
        }
    }

    public void ToggleMenu () {
        pauseMenu.enabled = !pauseMenu.enabled;

        if (pauseMenu.enabled) {
            Time.timeScale = 0;
        } else {
            Time.timeScale = 1;
        }
    }

    public void ReturnToMainMenu() {
        SceneManager.LoadScene(0);
    }
}