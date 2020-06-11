using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Playermovesin : MonoBehaviour
{
    const float lerpTime = 1f;
    float currentLerpTime;

    const float moveDistance = 600f;

    Vector3 startPos;
    Vector3 endPos;

    protected void Start()
    {
        startPos = transform.position;
        endPos = transform.position + transform.right * moveDistance;
    }

    protected void Update()
    {
        StartCoroutine(MyFunction());
    }
    
    IEnumerator MyFunction()
    {
        yield return new WaitForSeconds(2f);

        //reset when we press spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentLerpTime = 0f;
        }

        //increment timer once per frame
        currentLerpTime += Time.deltaTime;
        if (currentLerpTime > lerpTime)
        {
            currentLerpTime = lerpTime;
        }

        //lerp!
        //float perc = currentLerpTime / lerpTime;
        float perc = currentLerpTime / lerpTime;
        perc = Mathf.Sin(perc * Mathf.PI * 0.5f);
        transform.position = Vector3.Lerp(startPos, endPos, perc);
    }
}

//EASE OUT
//float t = currentLerpTime / lerpTime;
//t = Mathf.Sin(t* Mathf.PI* 0.5f);