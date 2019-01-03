using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript Instance { get; private set; }
    TextMeshProUGUI rating;
    TextMeshProUGUI combo;
    TextMeshProUGUI score;
    private void Awake()
    {
        if (Instance == null) { Instance = this; } else { Debug.Log("Warning: multiple " + this + " in scene!"); }
        rating = GameObject.FindGameObjectWithTag("RatingText").GetComponent<TextMeshProUGUI>();
        combo = GameObject.FindGameObjectWithTag("ComboText").GetComponent<TextMeshProUGUI>();
        score = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<TextMeshProUGUI>();
        combo.text = "" + 0;
        score.text = "" + 0;
    }

    public bool countDownDone = false;
    public GameObject countDownImage;

    public KeyCode a;
    public KeyCode b;
    public KeyCode c;
    public KeyCode d;
    public KeyCode e;

    public Transform keyA;
    public Transform keyB;
    public Transform keyC;
    public Transform keyD;
    public Transform keyE;
    public TextAsset BnBMedium;
    public TextAsset BnBEasy;
    public TextAsset BnBHard;
    public TextAsset test;
    string song;
    public beatmap map;
    // Start is called before the first frame update
    void Start()
    {
        TextAsset t = test;
        switch (map)
        {
            case beatmap.BnbMedium:
                t = BnBMedium;
                song = "BlipsandBlops";
                break;
            case beatmap.BnBEasy:
                t = BnBEasy;
                song = "BlipsandBlops";
                break;
            case beatmap.BnbHard:
                t = BnBHard;
                song = "BlipsandBlops";
                break;
        }


        MusicReader.Instance.readNspawn(t,song);

    }

    // Update is called once per frame
    void Update(){
      if (countDownDone) {
        countDownImage.SetActive(false);
      }
           
    }

    public void hitNote(Transform note, Transform key)
    {
        note.localScale = new Vector3(0, 0, 0);
        MoveObjectTime MOT = note.GetComponent<MoveObjectTime>();

        Debug.Log(note.position.sqrMagnitude - key.position.sqrMagnitude);
        float ratingf = Mathf.Abs(note.position.sqrMagnitude - key.position.sqrMagnitude);
        int streak = int.Parse(combo.text);
        float scoref = float.Parse(score.text);
        if (ratingf <  3)
        {
            scoref += 4 * streak;
            streak += 1;
            rating.text = "perfect";
        }
        else if(ratingf < 6)
        {
            scoref += 3 * streak;
            streak += 1;
            rating.text = "good";
        }
        else if(ratingf < 9)
        {
            scoref += 2 * streak;
            streak += 1;
            rating.text = "ok";
        }
        else if(ratingf < 12)
        {
            scoref += 1 * streak;
            rating.text = "bad";
        }
        else
        {
            streak = 0;
            rating.text = "miss";
        }
        score.text = "" + scoref;
        combo.text = "" + streak;
    }
    
}
