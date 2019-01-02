using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

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
      pauseMenuUI.SetActive(false);
      Time.timeScale = 1f;
      GameIsPaused = false;
    }

    // pause function
    void Pause() {
      pauseMenuUI.SetActive(true);
      Time.timeScale = 0f;
      GameIsPaused = true;
    }

    public void LoadMenu() {
      Debug.Log("Loading menu...");
      Time.timeScale = 1f;
      // Once main menu is ready
      // file/build settings/scenes to build
      // SceneManagement.LoadScene(name of menu scene)
    }

    public void QuitGame() {
      Debug.Log("Quitting game...");
      // Application.Quit()
    }
}
