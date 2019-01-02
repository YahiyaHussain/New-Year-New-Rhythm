using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicReader : MonoBehaviour
{
    int nMeasures;
    int nBeatFractions;
    noteInfo[] music; // false means no sound is played then, true means there is

    bool[] OuterLeftNotes;
    bool[] InnerLeftNotes;
    bool[] MiddleNotes;
    bool[] InnerRightNotes;
    bool[] OuterRightNotes;

    private void Start()
    {
        readnwrite.ReadString();
    }

    private void compileMusic()
    {

    }

}
