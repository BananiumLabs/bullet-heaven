using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Image mapOverlay;

    // public SpriteRenderer hudOverlay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() {
        ScoreCounter.ResetValues();
        StartCoroutine(FadeImages());
    }

    /// Fade the hud overlay out while simultaneously fading in the map overlay
    IEnumerator FadeImages() {

        while(mapOverlay.color.a < 1f) {
            mapOverlay.color = new Color(mapOverlay.color.r, mapOverlay.color.g, mapOverlay.color.b, mapOverlay.color.a + 0.01f);
            // hudOverlay.color = new Color(hudOverlay.color.r, hudOverlay.color.g, hudOverlay.color.b, hudOverlay.color.a + 0.01f);
            yield return new WaitForSeconds(0.02f);
        }

        SceneManager.LoadScene(1);
    }


    public void Quit() {
        Application.Quit();
    }

    public void ReturnToMenu() {
        SceneManager.LoadScene(0);
    }
}
