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
        string path = "Assets/Resources/test.txt";
        compileMusic(path);
    }

    private void compileMusic(string path)
    {
        string data = readnwrite.ReadString(path);
        string[] lines = data.Split('\n');
        music = new noteInfo[lines.Length];
        nMeasures = lines.Length;
        string[] tempLine;
        nBeatFractions = int.Parse(lines[0]);
        nMeasures = int.Parse(lines[1]);
        for (int i = 2; i < music.Length; i++)
        {
            tempLine = lines[1].Split(' ');
            if (tempLine[0].Equals("1"))
            {
                music[i].isNote = true;
                music[i].noteLength = int.Parse(tempLine[1]);
                pressType t = pressType.NULL;
                switch (tempLine[2])
                {
                    #region cases
                    case "a":
                        t = pressType.a;
                        break;
                    case "b":
                        t = pressType.b;
                        break;
                    case "c":
                        t = pressType.c;
                        break;
                    case "d":
                        t = pressType.d;
                        break;
                    case "e":
                        t = pressType.e;
                        break;
                    case "ab":
                        t = pressType.ab;
                        break;
                    case "ac":
                        t = pressType.ac;
                        break;
                    case "ad":
                        t = pressType.ad;
                        break;
                    case "ae":
                        t = pressType.ae;
                        break;
                    case "bc":
                        t = pressType.bc;
                        break;
                    case "bd":
                        t = pressType.bd;
                        break;
                    case "be":
                        t = pressType.be;
                        break;
                    case "cd":
                        t = pressType.cd;
                        break;
                    case "ce":
                        t = pressType.ce;
                        break;
                    case "de":
                        t = pressType.de;
                        break;
                        #endregion
                }
                music[i].pT = t;
            }
            else
            {
                music[0].isNote = false;
                music[i].noteLength = int.Parse(tempLine[1]);
            }
        }
    }

}
