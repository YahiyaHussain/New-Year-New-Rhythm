using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Conductor : MonoBehaviour
{
    public static Conductor Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null) { Instance = this; } else { Debug.Log("error too many "+ name); }
    }

    public float bpm;
    public float crotchet;
    public float offset;
    public float[] songPositions;
    public float pitch;
    // Start is called before the first frame update
    public bool playmusic;
    public bool sendblocks;
    public TextMeshProUGUI text;

    void Start()
    {


        songPositions = new float[2];
        songPositions[0] = 0;
    }
    int i = 0;
    int j = 0;
    int k = 0;
    noteInfo nI;
    public string song; // referenced by pausemenu.cs
    bool onlyOnce1 = false;
    bool onlyOnce2 = false;
    float dsptimesong;
    private void FixedUpdate()
    {
        Debug.Log("amIpaused");
        if (playmusic && !onlyOnce2)
        {
            onlyOnce2 = true;
            dsptimesong = (float)AudioSettings.dspTime;
        }
        Debug.Log(playmusic);
        if (playmusic)
        {
            Debug.Log("?");
            allowedToPause = true;
            songPositions[0] = (float)(AudioSettings.dspTime - dsptimesong) * pitch;

        }
        else if (allowedToPause)
        {
            //dsptimesong += (float)AudioSettings.dspTime - dsptimesong;
        }
        if (playmusic && !onlyOnce1 && songPositions[0] >= 2 - offset)
        {
            onlyOnce1 = true;
            AudioManager.instance.Play(song);
        }

        if (playmusic && songPositions[0] - 2f > MusicReader.Instance.music[MusicReader.Instance.music.Length - 1].songPos)
        {
            GameManagerScript.Instance.EndGame();
        }
        


        if (playmusic && i < MusicReader.Instance.music.Length && MusicReader.Instance.music[i].songPos <= songPositions[0] - (2))
        {
            if (i == 0)
            {

                //AudioManager.instance.Play(song);
            }
            if (MusicReader.Instance.music[i].isNote)
            {
                //AudioManager.instance.Play("test");
                
            }
            i++;
        }


        if (playmusic && j < MusicReader.Instance.music.Length && MusicReader.Instance.music[j].songPos <= songPositions[0])
        {
            Debug.Log("got here");
            if (j == 0)
            {
                Debug.Log("huh");
                //StartCoroutine(startConducting(0, song));
            }
            if (MusicReader.Instance.music[j].isNote)
            {
                float f = (float)AudioSettings.dspTime;
                nI = MusicReader.Instance.music[j];

                foreach (pressType pT in nI.pT)
                {
                    MoveObjectTime t = null;
                    switch (pT)
                    {
                        case pressType.a:
                            t = ObjectPooler.Instance.poolDictionary["A"].Dequeue().GetComponent<MoveObjectTime>();
                            t.transform.position = new Vector3(-4, 1.4f, 40);
                            break;
                        case pressType.b:
                            t = ObjectPooler.Instance.poolDictionary["B"].Dequeue().GetComponent<MoveObjectTime>();
                            t.transform.position = new Vector3(-2, 1.4f, 40);
                            break;
                        case pressType.c:
                            t = ObjectPooler.Instance.poolDictionary["C"].Dequeue().GetComponent<MoveObjectTime>();
                            t.transform.position = new Vector3(0, .5f, 40);
                            break;
                        case pressType.d:
                            t = ObjectPooler.Instance.poolDictionary["D"].Dequeue().GetComponent<MoveObjectTime>();
                            t.transform.position = new Vector3(2, 1.4f, 40);
                            break;
                        case pressType.e:
                            t = ObjectPooler.Instance.poolDictionary["E"].Dequeue().GetComponent<MoveObjectTime>();
                            t.transform.position = new Vector3(4, 1.4f, 40);
                            break;
                    }
                    t.myInfo = nI;
                    t.myType = pT;
                    t.gameObject.SetActive(true);
                    //Debug.Log((float)AudioSettings.dspTime - f);
                    StartCoroutine(t.MoveToPosition(t.targetObject.transform.position + new Vector3(0, .9f,0), (2) - ((float)AudioSettings.dspTime - f), false));
                    //Debug.Log((float)AudioSettings.dspTime - f);                                     
                }
            }

            j++;
           
        }
    }
    bool allowedToPause;

    // Update is called once per frame
    public IEnumerator startsConducting(int i, string s)
    {
        song = s;
        float dsptimesong = (float)AudioSettings.dspTime;
        //AudioManager.instance.Play(song);
        while (true)
        {
            if (playmusic &&!onlyOnce1 && songPositions[i] >= 2 - offset)
            {
                onlyOnce1 = true;
                AudioManager.instance.Play(song);
            }
            if (playmusic)
            {
                allowedToPause = true;
                songPositions[i] = (float)(AudioSettings.dspTime - dsptimesong) * pitch;
                
            }
            
            yield return new WaitForEndOfFrame();
        }
    }
}
