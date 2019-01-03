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
    public float offset;
    public float songPosition;
    public float pitch;
    // Start is called before the first frame update
    void Start()
    {
        
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
