using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Bossshadow : MonoBehaviour
{

    public Image RGBTilBoss;                //Image object som skal "Fades" inn

    /**********************************************************************//**
    * Funksjon som blir kalt en gang og før alle andre frames.
    *
    * Antall ganger tilkalt er statisk og en gang.
    * Scriptet i helhet har som hensikt å ta ett Image object og "Fade" det inn
    * etter to sekunder.
    * Denne funksjonen setter medsendt object sitt Image sin canvasRendered sin
    * Alpha (A verdien du ser sammen med andre RGB fargene på bildet sin Color)
    * til null og deretter etter to sekunder økes Alpha og bildet blir synlig.
    * Scriptet blir for eksempel brukt på noen Image objecter i BossIntro scene
    **************************************************************************/
    void Start()
    {
        RGBTilBoss.canvasRenderer.SetAlpha(0.0f);   //Alpha 0f, bildet usynlig
    
        StartCoroutine(Fadein());             //Øker Alpha til bildet er synlig

    }


    /**********************************************************************//**
    * Funksjon for å øke et Image sin Alpha fra 0 til synlig.
    * 
    * Funksjon er IEnumerator for å ha ventetid (WaitForSeconds(2f))
    **************************************************************************/
    IEnumerator Fadein()
    {
        yield return new WaitForSeconds(2f);               //Vent i to sekunder
        RGBTilBoss.CrossFadeAlpha(1, 1, false);                   //Fra 0 til 1
    }

}
