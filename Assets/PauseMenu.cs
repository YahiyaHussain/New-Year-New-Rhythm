using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public Image Countdown3;
    public Image Countdown2;
    public Image Countdown1;

    private void Awake() {
        StartCoroutine("Countdown");
    }

    // Coroutine for countdown
    IEnumerator Countdown() {
        Time.timeScale = 0f;

        Countdown3.enabled = true;
        Debug.Log("3");
        yield return new WaitForSecondsRealtime(1);
        Countdown3.enabled = false;

        Countdown2.enabled = true;
        Debug.Log("2");
        yield return new WaitForSecondsRealtime(1);
        Countdown2.enabled = false;

        Countdown1.enabled = true;
        Debug.Log("1");
        yield return new WaitForSecondsRealtime(1);
        Countdown1.enabled = false;

        Debug.Log("GO!");
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    // pause and resume game using esc
    void Update() {
      if (Input.GetKeyDown(KeyCode.Escape)) {
        if (GameIsPaused) {
            Resume();
        } else {
            Pause();
        }
      }
    }

    // resume function
    public void Resume() {
        StartCoroutine("Countdown");
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
    }

    // pause function
    void Pause() {
        StopCoroutine("Countdown");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu() {
      Debug.Log("Loading menu...");
      Time.timeScale = 1f;
      SceneManager.LoadScene("menu");
    }

    public void QuitGame() {
      Debug.Log("Quitting game...");
      Application.Quit();
    }
}
