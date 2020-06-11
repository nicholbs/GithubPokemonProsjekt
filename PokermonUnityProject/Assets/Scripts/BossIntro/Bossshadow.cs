using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Bossshadow : MonoBehaviour
{

    public Image RGBTilBoss;
 
    void Start()
    {
        RGBTilBoss.canvasRenderer.SetAlpha(0.0f);
    
        StartCoroutine(Fadein());

    }


    IEnumerator Fadein()
    {
        yield return new WaitForSeconds(2f);
        RGBTilBoss.CrossFadeAlpha(1, 1, false);
    }

}
