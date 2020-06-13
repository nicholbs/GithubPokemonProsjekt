using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Playermovesin : MonoBehaviour
{
    const float lerpTime = 1f;
                            //>Tid object har på å gå fra StartPos til SluttPos
    float currentLerpTime;                                   
    /*
     * Brukt for å regne ut hvor mye tid som er igjenn av fastsatt 
     * tid for object til å gå fra startPos til sluttPos
     */

    public float moveDistance = 600f;  //Distansen object beveger seg til høyre

    Vector3 startPos;                               //Start posisjon til object
    Vector3 endPos;                                 //Slutt posisjon til object

    /**********************************************************************//**
    * Funksjon som blir kalt en gang og før alle andre frames.
    *
    * Antall ganger tilkalt er statisk og en gang.
    * Scriptet i helhet har som hensikt å bevege et object fra et fastsatt
    * punkt til et annet. Bevegelsen går "smooth".
    * Funksjonen henter start pos fra object og regner ut endPos med startPos.
    * 
    * Scriptet blir brukt i player objectet i BossIntro.
    **************************************************************************/
    protected void Start()
    {
        startPos = transform.position;             //Henter posisjon til object
        endPos = transform.position + transform.right * moveDistance;
                                                    //>Regner ut slutt posisjon
    }

    /**********************************************************************//**
    * Funksjon som blir kalt en gang hver frame.
    *
    * Antall ganger tilkalt er dynamisk og avhenger av frameRate. 
    * Funksjonen oppdaterer posisjon til object hver frame.
    * 
    * @see IEnumerator MyFunction() - funksjon som oppdaterer pos
    **************************************************************************/
    protected void Update()
    {
        StartCoroutine(MyFunction());
    }

    /**********************************************************************//**
    * Funksjon tar nåværende pos og regner ut neste pos inntil nådd sluttPos.
    * 
    * Funksjonen er IEnumerator for ventetid (WaitForSeconds).
    **************************************************************************/
    IEnumerator MyFunction()
    {
        yield return new WaitForSeconds(2f);                         //Ventetid

        //increment timer once per frame
        currentLerpTime += Time.deltaTime;//Regner ut nåværende tid i bevegelse
        if (currentLerpTime > lerpTime)       //Dersom ikke mer tid i bevegelse
        {
            currentLerpTime = lerpTime;        //Sett til fastsatt tid/maks tid
        }

      
        float perc = currentLerpTime / lerpTime;
        perc = Mathf.Sin(perc * Mathf.PI * 0.5f);
        transform.position = Vector3.Lerp(startPos, endPos, perc);
                   /*
                    * Noe matte utregning, og oppdaterer object sin posisjon
                    */
    }
}
