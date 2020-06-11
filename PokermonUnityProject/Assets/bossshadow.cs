using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Bossshadow : MonoBehaviour
{



    public Image RGBTilBoss;
  
    // Start is called before the first frame update
    void Start()
    {
        RGBTilBoss.canvasRenderer.SetAlpha(0.0f);
        //var tempColor = RGBTilBoss.GetComponent<Image>().color;
        //tempColor.r = 0f;
        //tempColor.g = 0f;
        //tempColor.b = 0f;

        //RGBTilBoss.color = tempColor;
        StartCoroutine(fadein());

    }


    IEnumerator fadein()
    {
        yield return new WaitForSeconds(2f);
        RGBTilBoss.CrossFadeAlpha(1, 2, false);
    }

    //void Update()
    //{

    //    var tempColor = RGBTilBoss.GetComponent<Image>().color;
    //    if (tempColor.r <= 255)
    //    {
    //        tempColor.r += 2.55f;
    //        tempColor.g += 2.55f;
    //        tempColor.b += 2.55f;
    //        RGBTilBoss.color = tempColor;
    //    }
    //    else
    //    {
    //        tempColor.r += 2.55f;
    //        tempColor.g += 2.55f;
    //        tempColor.b += 2.55f;
    //        RGBTilBoss.color = tempColor;
    //    }

    //}


}
