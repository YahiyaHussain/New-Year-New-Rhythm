using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class fadeAwayText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startFading());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator startFading()
    {
        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
        yield return new WaitForSeconds(1);
        for (int i = 0; i < 50; i++)
        {
            text.color -= new Color(0, 0, 0, i / 50.0f);
            yield return new WaitForSeconds(0.03f);
        }

    }
}
