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
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null) { Instance = this; } else { Destroy(Instance); Instance = this; }
        DontDestroyOnLoad(gameObject);
    }
    public void changeOffset()
    {
        offset = float.Parse(I.text);
        Debug.Log("offset is: " + float.Parse(I.text));
    }
    // Update is called once per frame

}
