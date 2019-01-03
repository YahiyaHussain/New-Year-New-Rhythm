using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicReader : MonoBehaviour
{
    public static MusicReader Instance { get; private set; }
    void Awake()
    {
        if (Instance == null) { Instance = this; } else { Debug.Log("Warning: multiple " + this + " in scene!"); }
    }
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
    public MoveObjectTime[] MOTS;
    public Transform[] Dests;
    public void readNspawn()
    {
        string path = "Assets/Resources/test.txt";
        compileMusic(path);
        AM = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        StartCoroutine(playMusic());
        StartCoroutine(spawnBlocks());
    }
    IEnumerator spawnBlocks()
    {
        foreach(noteInfo nI in music)
        {
            float f = (float)AudioSettings.dspTime;
            if (nI.isNote)
            {            
                foreach (pressType pT in nI.pT)
                {
                    int index = 0;
                    MoveObjectTime t = null;
                    switch (pT)
                    {
                        case pressType.a:
                            index = 0;
                            break;
                        case pressType.b:
                            index = 1;
                            break;
                        case pressType.c:
                            index = 2;
                            break;
                        case pressType.d:
                            index = 3;
                            break;
                        case pressType.e:
                            index = 4;
                            break;
                    }
                    t = MOTS[index];
                    MOTS[index].myInfo = nI;
                    MOTS[index].myType = pT;
                    StartCoroutine(t.MoveToPosition(Dests[index].position, 2));
                    //Debug.Log((float)AudioSettings.dspTime - f);                                     
                }
                yield return new WaitForSeconds(nI.noteLength - (float)AudioSettings.dspTime + f);
            }
            else
            {
                //Debug.Log(Time.time - f);
                yield return new WaitForSeconds(nI.noteLength - (float)AudioSettings.dspTime + f);
            }
        }
    }
    IEnumerator playMusic()
    {
        yield return new WaitForSeconds(2);
        StartCoroutine(Conductor.Instance.startConducting());
        foreach (noteInfo nI in music)
        {
            if (nI.isNote)
            {
                AM.Play("test");
                //Debug.Log("hello");
                yield return new WaitForSeconds(nI.noteLength);
            }
            else
            {
                yield return new WaitForSeconds(nI.noteLength);
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
        float pressTime = 0;
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
                string a = tempLine[2];
                if (a[a.Length - 1] == '\n' || a[a.Length - 1] == 13)
                {
                    a = a.Substring(0, a.Length - 1);
                }
                else
                {
                }
                pressType[] t = null;
                switch (a)
                {
                    #region cases
                    case "a":
                        t = new pressType[1];
                        t[0] = pressType.a;
                        break;
                    case "b":
                        t = new pressType[1];
                        t[0] = pressType.b;
                        break;
                    case "c":
                        t = new pressType[1];
                        t[0] = pressType.c;
                        break;
                    case "d":
                        t = new pressType[1];
                        t[0] = pressType.d;
                        break;
                    case "e":
                        t = new pressType[1];
                        t[0] = pressType.e;
                        break;
                    case "ab":
                        t = new pressType[2];
                        t[0] = pressType.a;
                        t[1] = pressType.b;
                        break;
                    case "ac":
                        t = new pressType[2];
                        t[0] = pressType.a;
                        t[1] = pressType.c;
                        break;
                    case "ad":
                        t = new pressType[2];
                        t[0] = pressType.a;
                        t[1] = pressType.d;
                        break;
                    case "ae":
                        t = new pressType[2];
                        t[0] = pressType.a;
                        t[1] = pressType.e;
                        break;
                    case "bc":
                        t = new pressType[2];
                        t[0] = pressType.b;
                        t[1] = pressType.c;
                        break;
                    case "bd":
                        t = new pressType[2];
                        t[0] = pressType.b;
                        t[1] = pressType.d;
                        break;
                    case "be":
                        t = new pressType[2];
                        t[0] = pressType.b;
                        t[1] = pressType.e;
                        break;
                    case "cd":
                        t = new pressType[2];
                        t[0] = pressType.c;
                        t[1] = pressType.d;
                        break;
                    case "ce":
                        t = new pressType[2];
                        t[0] = pressType.c;
                        t[1] = pressType.e;
                        break;
                    case "de":
                        t = new pressType[2];
                        t[0] = pressType.d;
                        t[1] = pressType.e;
                        break;
                    #endregion
                    default:
                        t = null;
                        break;
                }
                music[i - 2].pT = t;
            }
            else
            {
                music[i - 2].isNote = false;
                //Debug.Log(measureCount);

                //string s = tempLine[1];
            }
            music[i - 2].noteLength = (int.Parse(tempLine[1]) / (float)nBeatFractions) * secondsPerMeasure;
            pressTime += music[i - 2].noteLength;
            music[i - 2].songPos = pressTime;
        }
        Debug.Log(music[music.Length - 1].songPos);
    }

}
