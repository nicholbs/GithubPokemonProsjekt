using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ReveilShadow : MonoBehaviour
{
    private float alpha = 0f;
    private float red = 0f;
    private float green = 0f;
    private float blue = 0f;

   
    private const float maxAlpha = 1f;

    // Start is called before the first frame update
    void Start()
    {

        Color objectColor = new Color(0, 0, 0, 0);
        this.GetComponent<Renderer>().material.color = objectColor;
    }

    
    void Update()
    {
        if (alpha < maxAlpha)
        {
        alpha += 0.0008f;
        red += 0.0008f;
        green += 0.0008f;
        blue += 0.0008f;
        }


        Color objectColor = new Color(red, green, blue, alpha);
        this.GetComponent<Renderer>().material.color = objectColor;

    }
}
