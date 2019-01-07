using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressKey : MonoBehaviour
{
    public KeyCode k;
    public Sprite[] buttons;
    public int index;
    private SpriteRenderer SR;
    // Start is called before the first frame update
    void Start()
    {
        //buttons = Resources.LoadAll<Sprite>("button");
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(k))
        {
            SR.sprite = buttons[index+1];
            Collider[] c = Physics.OverlapBox(transform.position, 0.8f* Vector3.one);
            if (c.Length > 0)
            {
               //s Debug.Log;
                GameManagerScript.Instance.hitNote(c[0].transform, transform);
            }
            AudioManager.Instance.Play("test");
        }
        if (Input.GetKeyUp(k))
        {
            SR.sprite = buttons[index];
        }
    }
}
