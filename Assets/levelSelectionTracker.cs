using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelSelectionTracker : MonoBehaviour
{
    public static levelSelectionTracker Instance;
    public beatmap chosenBeatmap = beatmap.BnBEasy;
    public float offset = -10;
    public InputField I;
    public float volumeLevel = 1;
    // Start is called before the first frame update
    private void OnEnable()
    {
        if (Instance == null) { Instance = this; } else { Destroy(gameObject); }
        DontDestroyOnLoad(gameObject);
    }

    public void changeOffset()
    {
        offset = float.Parse(I.text);
        Debug.Log("offset is: " + float.Parse(I.text));
    }
    // Update is called once per frame

}
