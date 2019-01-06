using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class begin : MonoBehaviour
{
    public GameObject stuff;
    public SpriteRenderer Logo;
    public SpriteRenderer black;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(timeThings());
    }

    IEnumerator timeThings()
    {

        AudioManager.Instance.Play("startup");
        for (int i = 0; i < 60; i++)
        {
            if (Input.anyKey)
            {
                AudioManager.instance.Stop("startup");
                stuff.SetActive(true);
                Logo.enabled = false;
                black.enabled = false;
                AudioManager.Instance.Play("title");
                yield break;
            }
            Debug.Log(i);
            Logo.color = Logo.color + new Color(0, 0, 0, i / 60.0f);
            yield return new WaitForSeconds(.05f);
        }
        for (int i = 60; i >= 0; i--)
        {
            if (Input.anyKey)
            {
                AudioManager.instance.Stop("startup");
                stuff.SetActive(true);
                black.enabled = false;
                Logo.enabled = false;
                AudioManager.Instance.Play("title");
                yield break;
            }
            Logo.color = Logo.color - new Color(0, 0, 0, i / 60.0f);

            yield return new WaitForSeconds(.05f);
        }
        AudioManager.Instance.Play("title");
        black.enabled = false;
        stuff.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
