using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelSelectionTracker : MonoBehaviour
{
    public static levelSelectionTracker Instance;
    public beatmap chosenBeatmap = beatmap.BnBEasy;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null) { Instance = this; } else { Destroy(Instance); Instance = this; }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        chosenBeatmap = SelectMenu.Instance.chosenBeatmap;
    }
}
