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
    public float Countdownbpm;
    public static bool initialcountdown = true;
    public string song;

    // inital countdown
    private void Start() {
        StartCoroutine("Countdown");
    }

    // Update is called once per frame
    // pause and resume game using esc
    void Update() {
        song = Conductor.Instance.song;
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused) {
                Resume();
        }   else {
                Pause();
        }
      }
    }

    // Coroutine for countdown
    IEnumerator Countdown()
    {
        Countdownbpm = ((Conductor.Instance.bpm) / 240f);
        Time.timeScale = 0f;

        AudioManager.Instance.Play("test");
        Countdown3.enabled = true;
        //Debug.Log("3");
        yield return new WaitForSecondsRealtime(Countdownbpm);
        Countdown3.enabled = false;

        AudioManager.Instance.Play("test");
        Countdown2.enabled = true;
        //Debug.Log("2");
        yield return new WaitForSecondsRealtime(Countdownbpm);
        Countdown2.enabled = false;

        AudioManager.Instance.Play("test");
        Countdown1.enabled = true;
        //Debug.Log("1");
        yield return new WaitForSecondsRealtime(Countdownbpm);
        Countdown1.enabled = false;

        //Debug.Log("GO!");
        if (!initialcountdown)
            AudioManager.instance.Play(GameManagerScript.Instance.song);
        Conductor.Instance.playmusic = true;
        Time.timeScale = 1f;
        initialcountdown = false;
    }

    // resume function
    public void Resume() {
        Time.timeScale = 1f;
        initialcountdown = true;
        SceneManager.LoadScene(1);
    }

    // pause function
    void Pause() {
        StopCoroutine("Countdown");
        AudioManager.instance.Stop(song);
        Time.timeScale = 0f;
        Conductor.Instance.playmusic = false;
        Countdown3.enabled = false;
        Countdown2.enabled = false;
        Countdown1.enabled = false;
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
    }

    public void LoadMenu() {
        GameIsPaused = false;
        initialcountdown = true;
        Debug.Log("Loading menu...");
      Time.timeScale = 1f;
      SceneManager.LoadScene("menu");
    }

    public void QuitGame() {
      Debug.Log("Quitting game...");
      Application.Quit();
    }
}
