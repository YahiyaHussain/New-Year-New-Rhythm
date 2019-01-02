using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum pressType //a = outerLeft b = innerLeft c = middle d = innerRight e = outerRight, a combo means both
{
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
    bool isNote;
    int noteLength;
    pressType pT;

}