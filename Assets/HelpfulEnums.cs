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
    ab,
    ac,
    ad,
    ae,
    bc,
    bd,
    be,
    cd,
    ce,
    de
}

public struct noteInfo
{
    public bool isNote;
    //public bool isHeld // in case we want holdin notes, (no Im not doing notes held in parallel for different durations, too annoying sounding)
    public int noteLength; //number of beatFractions til next note, 
    public pressType pT;
}