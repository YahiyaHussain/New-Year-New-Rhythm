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
    public float offset = .2f;
    public float songPosition;
    public float pitch;
    // Start is called before the first frame update
    public bool playmusic;
    void Start()
    {
        
    }
    int i = 0;
    noteInfo nI;
    private void Update()
    {
        if (playmusic && i < MusicReader.Instance.music.Length && MusicReader.Instance.music[i].songPos < songPosition)
        {
            if (MusicReader.Instance.music[i].isNote)
            {
                AudioManager.instance.Play("test");
            }
            i++;
        }
    }
    // Update is called once per frame
    public IEnumerator startConducting()
    {
        float dsptimesong = (float)AudioSettings.dspTime;
        while (true)
        {
            songPosition = (float)(AudioSettings.dspTime - dsptimesong) * pitch - offset;
            yield return new WaitForEndOfFrame();
        }
    }
}
