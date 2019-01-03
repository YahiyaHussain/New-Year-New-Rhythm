using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null) { Instance = this; } else { Debug.Log("Warning: multiple " + this + " in scene!"); }
    }

    public bool countDownDone = false;
    public GameObject countDownImage;

    public KeyCode a;
    public KeyCode b;
    public KeyCode c;
    public KeyCode d;
    public KeyCode e;

    public Transform keyA;
    public Transform keyB;
    public Transform keyC;
    public Transform keyD;
    public Transform keyE;

    // Start is called before the first frame update
    void Start()
    {
        MusicReader.Instance.readNspawn();

    }

    // Update is called once per frame
    void Update(){
      if (countDownDone) {
        countDownImage.SetActive(false);
      }
           
    }

    public void hitNote(Transform note, Transform key)
    {
        note.localScale = new Vector3(0, 0, 0);
        MoveObjectTime MOT = note.GetComponent<MoveObjectTime>();

        Debug.Log(note.position.sqrMagnitude - key.position.sqrMagnitude);
        float score = Mathf.Abs(note.position.sqrMagnitude - key.position.sqrMagnitude);
        if (score <  3)
        {
            Debug.Log("perfect");
        }
        else if(score < 6)
        {
            Debug.Log("good");
        }
        else if(score < 9)
        {
            Debug.Log("ok");
        }
        else if(score < 12)
        {
            Debug.Log("bad");
        }
        else
        {
            Debug.Log("miss");
        }
    }
    
}
