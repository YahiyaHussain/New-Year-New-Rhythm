using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SelectMenu : MonoBehaviour
{
    public static SelectMenu Instance;
    public beatmap chosenBeatmap = beatmap.BnBEasy;

    public TextMeshProUGUI songText;
    public TextMeshProUGUI diffText;
    // Start is called before the first frame update
    void Start()
    {
        chosenBeatmap = levelSelectionTracker.Instance.chosenBeatmap;
        Instance = this;
        switch (chosenBeatmap)
        {
            case beatmap.BnBEasy:
                diffText.text = "Easy";
                songText.text = "Blips and Blop";
                chosenBeatmap = beatmap.UnderwaterEasy;
                break;
            case beatmap.BnbMedium:
                diffText.text = "Medium";
                songText.text = "Blips and Blop";
                chosenBeatmap = beatmap.UnderwaterMedium;
                break;
            case beatmap.BnbHard:
                diffText.text = "Hard";
                songText.text = "Blips and Blop";
                chosenBeatmap = beatmap.UnderwaterHard;
                break;
            case beatmap.UnderwaterEasy:
                diffText.text = "Easy";
                songText.text = "Underwater Flame";
                chosenBeatmap = beatmap.TangoEasy;
                break;
            case beatmap.UnderwaterMedium:
                diffText.text = "Medium";
                songText.text = "Underwater Flame";
                chosenBeatmap = beatmap.TangoMedium;
                break;
            case beatmap.UnderwaterHard:
                diffText.text = "Hard";
                songText.text = "Underwater Flame";
                chosenBeatmap = beatmap.TangoHard;
                break;
            case beatmap.TangoEasy:
                diffText.text = "Easy";
                songText.text = "Tango of the Firework King";
                chosenBeatmap = beatmap.EricEasy;
                break;
            case beatmap.TangoMedium:
                diffText.text = "Medium";
                songText.text = "Tango of the Firework King";
                chosenBeatmap = beatmap.EricMedium;
                break;
            case beatmap.TangoHard:
                diffText.text = "Hard";
                songText.text = "Tango of the Firework King";
                chosenBeatmap = beatmap.EricHard;
                break;
            case beatmap.EricEasy:
                diffText.text = "Easy";
                songText.text = "Eric the Electric";
                chosenBeatmap = beatmap.BnBEasy;
                break;
            case beatmap.EricMedium:
                diffText.text = "Medium";
                songText.text = "Eric the Electric";
                chosenBeatmap = beatmap.BnbMedium;
                break;
            case beatmap.EricHard:
                diffText.text = "Hard";
                songText.text = "Eric the Electric";
                chosenBeatmap = beatmap.BnbHard;
                break;
        }

    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void SongSelectionRightArrow()
    {
        switch (chosenBeatmap)
        {
            case beatmap.BnBEasy:
                songText.text = "Underwater Flame";
                chosenBeatmap = beatmap.UnderwaterEasy;
                break;
            case beatmap.BnbMedium:
                songText.text = "Underwater Flame";
                chosenBeatmap = beatmap.UnderwaterMedium;
                break;
            case beatmap.BnbHard:
                songText.text = "Underwater Flame";
                chosenBeatmap = beatmap.UnderwaterHard;
                break;
            case beatmap.UnderwaterEasy:
                songText.text = "Tango of the Firework King";
                chosenBeatmap = beatmap.TangoEasy;
                break;
            case beatmap.UnderwaterMedium:
                songText.text = "Tango of the Firework King";
                chosenBeatmap = beatmap.TangoMedium;
                break;
            case beatmap.UnderwaterHard:
                songText.text = "Tango of the Firework King";
                chosenBeatmap = beatmap.TangoHard;
                break;
            case beatmap.TangoEasy:
                songText.text = "Eric the Electric";
                chosenBeatmap = beatmap.EricEasy;
                break;
            case beatmap.TangoMedium:
                songText.text = "Eric the Electric";
                chosenBeatmap = beatmap.EricMedium;
                break;
            case beatmap.TangoHard:
                songText.text = "Eric the Electric";
                chosenBeatmap = beatmap.EricHard;
                break;
            case beatmap.EricEasy:
                songText.text = "Blips and Blops";
                chosenBeatmap = beatmap.BnBEasy;
                break;
            case beatmap.EricMedium:
                songText.text = "Blips and Blops";
                chosenBeatmap = beatmap.BnbMedium;
                break;
            case beatmap.EricHard:
                songText.text = "Blips and Blops";
                chosenBeatmap = beatmap.BnbHard;
                break;
        }
        levelSelectionTracker.Instance.chosenBeatmap = chosenBeatmap;
    }

    public void SongSelectionLeftArrow()
    {
        switch (chosenBeatmap)
        {
            case beatmap.BnBEasy:
                songText.text = "Eric the Electric";
                chosenBeatmap = beatmap.EricEasy;
                break;
            case beatmap.BnbMedium:
                songText.text = "Eric the Electric";
                chosenBeatmap = beatmap.EricMedium;
                break;
            case beatmap.BnbHard:
                songText.text = "Eric the Electric";
                chosenBeatmap = beatmap.EricHard;
                break;
            case beatmap.UnderwaterEasy:
                songText.text = "Blips and Blops";
                chosenBeatmap = beatmap.BnBEasy;
                break;
            case beatmap.UnderwaterMedium:
                songText.text = "Blips and Blops";
                chosenBeatmap = beatmap.BnbMedium;
                break;
            case beatmap.UnderwaterHard:
                songText.text = "Blips and Blops";
                chosenBeatmap = beatmap.BnbHard;
                break;
            case beatmap.TangoEasy:
                songText.text = "Underwater Flame";
                chosenBeatmap = beatmap.UnderwaterEasy;
                break;
            case beatmap.TangoMedium:
                songText.text = "Underwater Flame";
                chosenBeatmap = beatmap.UnderwaterMedium;
                break;
            case beatmap.TangoHard:
                songText.text = "Underwater Flame";
                chosenBeatmap = beatmap.UnderwaterHard;
                break;
            case beatmap.EricEasy:
                songText.text = "Tango of the Firework King";
                chosenBeatmap = beatmap.TangoEasy;
                break;
            case beatmap.EricMedium:
                songText.text = "Tango of the Firework King";
                chosenBeatmap = beatmap.TangoMedium;
                break;
            case beatmap.EricHard:
                songText.text = "Tango of the Firework King";
                chosenBeatmap = beatmap.TangoHard;
                break;
        }
        levelSelectionTracker.Instance.chosenBeatmap = chosenBeatmap;
    }

    public void DifficultySelectionLeftArrow()
    {
        switch (chosenBeatmap)
        {
            case beatmap.BnBEasy:
                diffText.text = "Hard";
                chosenBeatmap = beatmap.BnbHard;
                break;
            case beatmap.BnbMedium:
                diffText.text = "Easy";
                chosenBeatmap = beatmap.BnBEasy;
                break;
            case beatmap.BnbHard:
                diffText.text = "Medium";
                chosenBeatmap = beatmap.BnbMedium;
                break;
            case beatmap.UnderwaterEasy:
                diffText.text = "Hard";
                chosenBeatmap = beatmap.UnderwaterHard;
                break;
            case beatmap.UnderwaterMedium:
                diffText.text = "Easy";
                chosenBeatmap = beatmap.UnderwaterEasy;
                break;
            case beatmap.UnderwaterHard:
                diffText.text = "Medium";
                chosenBeatmap = beatmap.UnderwaterMedium;
                break;
            case beatmap.TangoEasy:
                diffText.text = "Hard";
                chosenBeatmap = beatmap.TangoHard;
                break;
            case beatmap.TangoMedium:
                diffText.text = "Easy";
                chosenBeatmap = beatmap.TangoEasy;
                break;
            case beatmap.TangoHard:
                diffText.text = "Medium";
                chosenBeatmap = beatmap.TangoMedium;
                break;
            case beatmap.EricEasy:
                diffText.text = "Hard";
                chosenBeatmap = beatmap.EricHard;
                break;
            case beatmap.EricMedium:
                diffText.text = "Easy";
                chosenBeatmap = beatmap.EricEasy;
                break;
            case beatmap.EricHard:
                diffText.text = "Medium";
                chosenBeatmap = beatmap.EricMedium;
                break;
        }
        levelSelectionTracker.Instance.chosenBeatmap = chosenBeatmap;
    }
    public void DifficultySelectionRightArrow()
    {
        switch (chosenBeatmap)
        {
            case beatmap.BnBEasy:
                diffText.text = "Medium";
                chosenBeatmap = beatmap.BnbMedium;
                break;
            case beatmap.BnbMedium:
                diffText.text = "Hard";
                chosenBeatmap = beatmap.BnbHard;
                break;
            case beatmap.BnbHard:
                diffText.text = "Easy";
                chosenBeatmap = beatmap.BnBEasy;
                break;
            case beatmap.EricEasy:
                diffText.text = "Medium";
                chosenBeatmap = beatmap.EricMedium;
                break;
            case beatmap.EricMedium:
                diffText.text = "Hard";
                chosenBeatmap = beatmap.EricHard;
                break;
            case beatmap.EricHard:
                diffText.text = "Easy";
                chosenBeatmap = beatmap.EricEasy;
                break;
            case beatmap.TangoEasy:
                diffText.text = "Medium";
                chosenBeatmap = beatmap.TangoMedium;
                break;
            case beatmap.TangoMedium:
                diffText.text = "Hard";
                chosenBeatmap = beatmap.TangoHard;
                break;
            case beatmap.TangoHard:
                diffText.text = "Easy";
                chosenBeatmap = beatmap.TangoEasy;
                break;
            case beatmap.UnderwaterEasy:
                diffText.text = "Medium";
                chosenBeatmap = beatmap.UnderwaterMedium;
                break;
            case beatmap.UnderwaterMedium:
                diffText.text = "Hard";
                chosenBeatmap = beatmap.UnderwaterHard;
                break;
            case beatmap.UnderwaterHard:
                diffText.text = "Easy";
                chosenBeatmap = beatmap.UnderwaterEasy;
                break;
        }
        levelSelectionTracker.Instance.chosenBeatmap = chosenBeatmap;
    }
}
