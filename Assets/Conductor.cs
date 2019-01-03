using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    public static Conductor Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null) { Instance = this; } else { Debug.Log("error too many "+ name); }
    }

    public float bpm;
    public float crotchet;
    public float offset = 0f;
    public float[] songPositions;
    public float pitch;
    // Start is called before the first frame update
    public bool playmusic;
    public bool sendblocks;
    void Start()
    {
        songPositions = new float[2];
    }
    int i = 0;
    int j = 0;
    noteInfo nI;
    string song;
    private void Update()
    {

        if (playmusic && i < MusicReader.Instance.music.Length && MusicReader.Instance.music[i].songPos < songPositions[0] - 2)
        {
            if (i == 0)
            {
                AudioManager.instance.Play(song);
            }
            if (MusicReader.Instance.music[i].isNote)
            {
                //AudioManager.instance.Play("test");
                
            }
            i++;
        }
        if (sendblocks && j < MusicReader.Instance.music.Length && MusicReader.Instance.music[j].songPos < songPositions[0])
        {
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
                            t.transform.position = new Vector3(-4, .5f, 40);
                            break;
                        case pressType.b:
                            t = ObjectPooler.Instance.poolDictionary["B"].Dequeue().GetComponent<MoveObjectTime>();
                            t.transform.position = new Vector3(-2, .5f, 40);
                            break;
                        case pressType.c:
                            t = ObjectPooler.Instance.poolDictionary["C"].Dequeue().GetComponent<MoveObjectTime>();
                            t.transform.position = new Vector3(0, .5f, 40);
                            break;
                        case pressType.d:
                            t = ObjectPooler.Instance.poolDictionary["D"].Dequeue().GetComponent<MoveObjectTime>();
                            t.transform.position = new Vector3(2, .5f, 40);
                            break;
                        case pressType.e:
                            t = ObjectPooler.Instance.poolDictionary["E"].Dequeue().GetComponent<MoveObjectTime>();
                            t.transform.position = new Vector3(4, .5f, 40);
                            break;
                    }
                    t.myInfo = nI;
                    t.myType = pT;
                    t.gameObject.SetActive(true);
                    //Debug.Log((float)AudioSettings.dspTime - f);
                    StartCoroutine(t.MoveToPosition(t.targetObject.transform.position, 2 - ((float)AudioSettings.dspTime - f) ));
                    //Debug.Log((float)AudioSettings.dspTime - f);                                     
                }
            }
            else
            {

            }
            j++;
        }
    }
    private void FixedUpdate()
    {
        
    }
    // Update is called once per frame
    public IEnumerator startConducting(int i, string s)
    {
        song = s;
        float dsptimesong = (float)AudioSettings.dspTime;
        while (true)
        {
            songPositions[i] = (float)(AudioSettings.dspTime - dsptimesong) * pitch - offset;
            yield return new WaitForEndOfFrame();
        }
    }
}
