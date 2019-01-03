using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// NOTE: code here derives heavily from https://answers.unity.com/questions/296347/move-transform-to-target-in-x-seconds.html
public class MoveObjectTime : MonoBehaviour
{
    public noteInfo myInfo;
    public pressType myType;
    public Vector3 origPos;
    [Tooltip("Time the object should take to reach the specified target.")]
    public float timeToReachTarget;

    [Tooltip("Object that this game object should be approaching.")]
    public GameObject targetObject;

    private bool isCurrentlyMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        origPos = transform.position;
        var targetPosition = targetObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void nUpdate()
    {
        if (targetObject != null)
        {
            var targetPosition = targetObject.GetComponent<Transform>();

            StartCoroutine(MoveToPosition(targetPosition.position, timeToReachTarget));
        }
    }

    public IEnumerator MoveToPosition(Vector3 position, float timeToMove)
    {
        position =  .1f*(position - transform.position) + position;
        timeToMove = 1.1f * timeToMove;
        float f = (float)AudioSettings.dspTime;
        if (isCurrentlyMoving)
        {
            yield break;
        }
        transform.localScale = Vector3.one;
        isCurrentlyMoving = true;
        var currentPos = transform.position;
        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            transform.position = Vector3.Lerp(currentPos, position, t);

            yield return null;
        }
        //Debug.Log((float)AudioSettings.dspTime - f);
        //Debug.Log(myInfo.songPos - Conductor.Instance.songPosition);
        string s = "";
        switch (myType)
        {
            case pressType.a:
                s = "A";
                break;
            case pressType.b:
                s = "B";
                break;
            case pressType.c:
                s = "C";
                break;
            case pressType.d:
                s = "D";
                break;
            case pressType.e:
                s = "E";
                break;
        }
        if (transform.localScale.magnitude > 0.1f)
        {
            GameManagerScript.Instance.hitNote(transform, targetObject.transform);
        }
        ObjectPooler.Instance.poolDictionary[s].Enqueue(gameObject);
        isCurrentlyMoving = false;
        gameObject.SetActive(false);
    }
}
