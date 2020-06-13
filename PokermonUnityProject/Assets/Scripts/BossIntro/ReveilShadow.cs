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

    /**********************************************************************//**
    * Funksjon som blir kalt en gang og før alle andre frames.
    *
    * Antall ganger tilkalt er statisk og en gang.
    * Scriptet i helhet har som hensikt å bli brukt på ett object med en
    * "renderer" component og setter sin material nullstiller sin color slik
    * objectet blir helt sort, for å så "fade" tilbake til lyst.
    * 
    * Scriptet blir ikke brukt per nå, men var tidligere i BossIntro scenen
    **************************************************************************/
    void Start()
    {

        Color objectColor = new Color(0, 0, 0, 0);     //nullstilt color object
        this.GetComponent<Renderer>().material.color = objectColor;
                                     //>Nullstiller object som script festet på
    }


    /**********************************************************************//**
    * Funksjon som blir kalt en gang hver frame.
    *
    * Antall ganger tilkalt er dynamisk og avhenger av frameRate. 
    * Funksjonen øker fargeverdiene til objectet script festet på gradvis til
    * den når maksverdien. Skaper "fade-in" effekt.
    **************************************************************************/
    void Update()
    {
        if (alpha < maxAlpha)                  //Dersom alpha ikke er nådd maks
        {
        alpha += 0.0008f;
        red += 0.0008f;
        green += 0.0008f;
        blue += 0.0008f;
                                                    //>Øker alle farge verdiene
        }


        Color objectColor = new Color(red, green, blue, alpha); 
        this.GetComponent<Renderer>().material.color = objectColor;
                               //>Plusser fargeverdiene til object script er på

    }
}
