using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public bool countDownDone = false;

    // Coroutine for countdown
    IEnumerator DelayTime() {
        yield return new WaitForSeconds(2f);
        Debug.Log("Waited 2 seconds");
        countDownDone = true;
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
      if (countDownDone) {
        Time.timeScale = 1f;
      }
    }

    // resume function
    public void Resume() {
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
        StartCoroutine("Delaytime");
    }

    // pause function
    void Pause() {
      pauseMenuUI.SetActive(true);
      Time.timeScale = 0f;
      GameIsPaused = true;
      countDownDone = false;
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
