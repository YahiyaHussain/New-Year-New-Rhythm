using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum pressType //a = outerLeft b = innerLeft c = middle d = innerRight e = outerRight, a combo means both
{
    NULL,
    a,
    b,
    c,
    d,
    e,
}

public struct noteInfo
{
    public bool isNote;
    //public bool isHeld // in case we want holdin notes, (no Im not doing notes held in parallel for different durations, too annoying sounding)
    public float noteLength; //time in seconds of note
    public pressType[] pT;
    public float songPos;
}