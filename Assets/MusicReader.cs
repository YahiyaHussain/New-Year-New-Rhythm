﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicReader : MonoBehaviour
{
    int nMeasures;
    float secondsPerMeasure = 2f;
    int nBeatFractions;
    noteInfo[] music; // false means no sound is played then, true means there is

    bool[] OuterLeftNotes;
    bool[] InnerLeftNotes;
    bool[] MiddleNotes;
    bool[] InnerRightNotes;
    bool[] OuterRightNotes;

    AudioManager AM;

    private void Start()
    {
        string path = "Assets/Resources/test.txt";
        compileMusic(path);
        AM = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        StartCoroutine(playMusic());
    }

    IEnumerator playMusic()
    {
        foreach(noteInfo nI in music)
        {
            if (nI.isNote)
            {
                AM.Play("test");
                Debug.Log("hello");
                yield return new WaitForSeconds((nI.noteLength / (float)nBeatFractions) * secondsPerMeasure);
            }
            else
            {
                yield return new WaitForSeconds((nI.noteLength / (float)nBeatFractions) * secondsPerMeasure);
            }
        }
    }

    private void compileMusic(string path)
    {
        string data = readnwrite.ReadString(path);
        string[] lines = data.Split('\n');
        nBeatFractions = int.Parse(lines[0]);
        nMeasures = int.Parse(lines[1]);
        music = new noteInfo[lines.Length - 2];
        string[] tempLine;

        for (int i = 2; i < lines.Length;i++)
        {

            tempLine = lines[i].Split(' ');
            if (tempLine.Length == 0)
            {
                Debug.Log("error empty line");
            }
            if (tempLine[0].Equals("1"))
            {
                music[i - 2].isNote = true;
                music[i - 2].noteLength = int.Parse(tempLine[1]);
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
                music[i - 2].pT = t;
            }
            else
            {
                music[i - 2].isNote = false;
                //Debug.Log(measureCount);

                //string s = tempLine[1];
                music[i - 2].noteLength = int.Parse(tempLine[1]);
            }
        }
    }

}
