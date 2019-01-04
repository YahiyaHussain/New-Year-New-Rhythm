using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    private GameManagerScript GMS;

    // Update is called once per frame
    // pause and resume game using esc
    void Update() {
      GMS = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
      if (Input.GetKeyDown(KeyCode.Escape)) {
        if (GameIsPaused) {
          Resume();
        } else {
          Pause();
        }
      }
      // check if countdown is done, then resume game
      if (GMS.countDownDone) {
        Time.timeScale = 1f;
      }
    }

    // resume function
    public void Resume() {
      pauseMenuUI.SetActive(false);
      GameIsPaused = false;
      GMS = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
      GMS.countDownImage.SetActive(true);
    }

    // pause function
    void Pause() {
      GMS = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
      GMS.countDownDone = false;
      GMS.countDownImage.SetActive(false);
      pauseMenuUI.SetActive(true);
      Time.timeScale = 0f;
      GameIsPaused = true;
    }

    public void LoadMenu() {
      Debug.Log("Loading menu...");
      GMS = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
      if (!GMS.countDownDone) {
        GMS.countDownDone = true;
        GMS.countDownImage.SetActive(false);
      }
      Time.timeScale = 1f;
      // Once main menu is ready
      // file/build settings/scenes to build
      // SceneManagement.LoadScene(name of menu scene)
    }

    public void QuitGame() {
      Debug.Log("Quitting game...");
        Application.Quit();
    }
}
