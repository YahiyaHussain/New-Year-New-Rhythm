using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressKey : MonoBehaviour
{
    public KeyCode k;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(k))
        {
            transform.localScale = new Vector3(1, .1f, 1);
            Collider[] c = Physics.OverlapBox(transform.position, 0.8f* Vector3.one);
            if (c.Length > 0)
            {
                GameManagerScript.Instance.hitNote(c[0].transform, transform);
            }
            AudioManager.Instance.Play("test");
        }
        if (Input.GetKeyUp(k))
        {
            transform.localScale = Vector3.one;
        }
    }
}
