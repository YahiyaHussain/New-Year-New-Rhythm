using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript Instance { get; private set; }
    TextMeshProUGUI rating;
    TextMeshProUGUI combo;
    TextMeshProUGUI score;

    public ParticleSystem Green;
    public ParticleSystem Red;
    public ParticleSystem Blue;
    public ParticleSystem Purple;
    public ParticleSystem Yellow;

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
    public TextAsset TangoEasy;
    public TextAsset TangoMedium;
    public TextAsset TangoHard;
    public TextAsset EricEasy;
    public TextAsset EricMedium;
    public TextAsset EricHard;
    public TextAsset UnderwaterEasy;
    public TextAsset UnderwaterMedium;
    public TextAsset UnderwaterHard;
    public TextAsset test;
    public string song;
    public beatmap map;



    public int perfectCount;
    public int goodCount;
    public int okCount;
    public int badCount;
    public int awfulCount;
    public int missCount;
    public int totalCount;

    public int maxStreak;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null) { Instance = this; } else { Debug.Log("Warning: multiple " + this + " in scene!"); }
        rating = GameObject.FindGameObjectWithTag("RatingText").GetComponent<TextMeshProUGUI>();
        combo = GameObject.FindGameObjectWithTag("ComboText").GetComponent<TextMeshProUGUI>();
        score = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<TextMeshProUGUI>();
        combo.text = "" + 0;
        score.text = "" + 0;
        maxStreak = 0;
        perfectCount = 0;
        goodCount = 0;
        okCount = 0;
        badCount = 0;
        awfulCount = 0;
        missCount = 0;
        totalCount = 0;
        TextAsset t = test;
        map = levelSelectionTracker.Instance.chosenBeatmap;
        switch (map)
        {
            case beatmap.BnbMedium:
                Conductor.Instance.offset = .02f;
                Conductor.Instance.bpm = 120;
                t = BnBMedium;
                song = "BlipsandBlops";
                break;
            case beatmap.BnBEasy:
                Conductor.Instance.offset = .02f;
                Conductor.Instance.bpm = 120;
                t = BnBEasy;
                song = "BlipsandBlops";
                break;
            case beatmap.BnbHard:
                Conductor.Instance.offset = .02f;
                Conductor.Instance.bpm = 120;
                t = BnBHard;
                song = "BlipsandBlops";
                break;
            case beatmap.TangoEasy:
                Conductor.Instance.bpm = 120;
                Conductor.Instance.offset = 0.135f;
                t = TangoEasy;
                song = "Tango";
                break;
            case beatmap.TangoMedium:
                Conductor.Instance.bpm = 120;
                Conductor.Instance.offset = 0.135f;
                t = TangoMedium;
                song = "Tango";
                break;
            case beatmap.TangoHard:
                Conductor.Instance.bpm = 120;
                Conductor.Instance.offset = 0.135f;
                t = TangoHard;
                song = "Tango";
                break;
            case beatmap.EricEasy:
                Conductor.Instance.bpm = 160;
                Conductor.Instance.offset = 0;
                t = EricEasy;
                song = "ErictheElectric";
                break;
            case beatmap.EricMedium:
                Conductor.Instance.bpm = 160;
                t = EricMedium;
                song = "ErictheElectric";
                break;
            case beatmap.EricHard:
                Conductor.Instance.bpm = 160;
                t = EricHard;
                song = "ErictheElectric";
                break;
            case beatmap.UnderwaterEasy:
                Conductor.Instance.bpm = 110;
                Conductor.Instance.offset = .12f;
                t = UnderwaterEasy;
                song = "Underwater";
                break;
            case beatmap.UnderwaterMedium:
                Conductor.Instance.bpm = 110;
                Conductor.Instance.offset = .12f;
                t = UnderwaterMedium;
                song = "Underwater";
                break;
            case beatmap.UnderwaterHard:
                Conductor.Instance.bpm = 110;
                Conductor.Instance.offset = .12f;
                t = UnderwaterHard;
                song = "Underwater";
                break;
        }
        Conductor.Instance.song = song;
        if (levelSelectionTracker.Instance.offset != -10)
        {
            Conductor.Instance.offset = levelSelectionTracker.Instance.offset;
        }

        MusicReader.Instance.readNspawn(t,song);

    }

    // Update is called once per frame

    IEnumerator sendgUp(Transform rocket)
    {
        for (int i = 0; i < 20; i++)
        {
            var origPos = rocket.position;
            var currentPos = rocket.position;
            var t = 0f;
            while (t < 1)
            {
                t += Time.deltaTime / 2;
                rocket.position += Vector3.up * .1f;
                yield return null;
            }
        }
    }
    public void hitNote(Transform note, Transform key)
    {

        note.localScale = new Vector3(0, 0, 0);
        MoveObjectTime MOT = note.GetComponent<MoveObjectTime>();

        float ratingf = Mathf.Abs(note.position.sqrMagnitude - key.position.sqrMagnitude);
        int streak = int.Parse(combo.text);
        if (streak > maxStreak) maxStreak = streak;
        float scoref = float.Parse(score.text);
        totalCount++;
        if (ratingf < 20)
        {
            //Debug.Log("why");
            string s = "";
            switch (note.GetComponent<MoveObjectTime>().myType)
            {
                case pressType.a:
                    s = "A";
                    Green.Emit(1);
                    break;
                case pressType.b:
                    Red.Emit(1);
                    s = "B";
                    break;
                case pressType.c:
                    Blue.Emit(1);
                    s = "C";
                    break;
                case pressType.d:
                    Purple.Emit(1);
                    s = "D";
                    break;
                case pressType.e:
                    Yellow.Emit(1);
                    s = "E";
                    break;
            }
            Debug.Log(s);
            Transform rocket = ObjectPooler.Instance.poolDictionary[s].Dequeue().transform;
            rocket.gameObject.SetActive(true);
            rocket.GetComponent<MoveObjectTime>().myType = note.GetComponent<MoveObjectTime>().myType;
            StartCoroutine(rocket.GetComponent<MoveObjectTime>().MoveToPosition(rocket.position + Vector3.up * 20, 1.69f, true));
        }
        if (ratingf < 5)
        {
            perfectCount++;
            scoref += 4 * streak;
            streak += 1;
            rating.text = "perfect";
        }
        else if(ratingf < 8)
        {
            goodCount++;
            scoref += 3 * streak;
            streak += 1;
            rating.text = "good";
        }
        else if(ratingf < 13)
        {
            okCount++;
            scoref += 2 * streak;
            streak += 1;
            rating.text = "ok";
        }
        else if(ratingf < 16)
        {
            badCount++;
            scoref += 1 * streak;
            rating.text = "bad";
        }
        else if(ratingf < 20)
        {
            awfulCount++;
            rating.text = "awful";
        }
        else
        {
            missCount++;
            streak = 0;
            rating.text = "miss";
        }

        score.text = "" + scoref;
        combo.text = "" + streak;
        if (streak > maxStreak) maxStreak = streak;
    }
    public Image EndGamePanel;
    public TextMeshProUGUI finalScore;
    public void EndGame()
    {

        EndGamePanel.enabled = true;
        StartCoroutine(Opaquen(EndGamePanel));
        float grade = (perfectCount + .95f * goodCount + .8f * okCount + .65f * badCount + .5f * awfulCount) / totalCount;

        
        string letter;
        if (grade >= 0.99) letter = "SS";
        else if (grade >= 0.95) letter = "S";
        else if (grade >= 0.9) letter = "A";
        else if (grade >= 0.8) letter = "B";
        else if (grade >= 0.7) letter = "C";
        else if (grade >= 0.6) letter = "D";
        else letter = "F";


        if (maxStreak == totalCount)
        {
            finalScore.text = "HighScore:" + '\n' + score.text + '\n' + '\n' + "Rating:" + '\n' + letter + '\n' + '\n' + "MaxCombo:"+  '\n' + "FULL COMBO!";
        }
        finalScore.text = "HighScore:" + '\n' + score.text + '\n' + '\n'+"Rating:" + '\n' + letter + '\n' + '\n' + "MaxCombo:" + '\n'+ maxStreak + "/" + totalCount;
        StartCoroutine(MainMenuTime());
    }
    bool onlyOnce;
    IEnumerator Opaquen(Image img)
    { 
        if (onlyOnce)
        {
            yield break;
        }
        onlyOnce = true;
        for (int i = 0; i < 30; i++)
        {
            img.color = new Color(img.color.r, img.color.g, img.color.b, i / 30.0f);
            yield return null;
        }
    }
    IEnumerator MainMenuTime()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }
    
}
