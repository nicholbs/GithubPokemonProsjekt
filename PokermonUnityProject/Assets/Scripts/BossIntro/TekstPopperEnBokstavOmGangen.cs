using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TekstPopperEnBokstavOmGangen : MonoBehaviour
{

    public float letterPause = 0.1f;            //Tid mellom hver bokstav vises

    string message;                   //Holder midlertidig texten i Text object
    Text textComp;                                 //variabel for Text objectet

    /**********************************************************************//**
    * Funksjon som blir kalt en gang og før alle andre frames.
    *
    * Antall ganger tilkalt er statisk og en gang.
    * Scriptet i helhet har som hensikt å ta et "Text" object sin text og få
    * hver bokstav til å "popp" inn på skjermen en om gangen etter hverandre.
    * Scriptet blir brukt på diverse Text objecter i BossIntro scenen.
    **************************************************************************/
    void Start()
    {
        textComp = GetComponent<Text>();     //variabel lik object script er på
        message = textComp.text;                    //Holder midlertidig texten
        textComp.text = "";                  //Nullstiller texten i Text object
        StartCoroutine(TypeText()); 
                              //>Popper bokstaver og putter dem i Text sin text
        
    }

    /**********************************************************************//**
    * Funksjon "popper" inn bokstaver og har ventetid mellom hver bokstav vises
    * 
    * Funksjonen er IEnumerator for ventetid (WaitForSeconds).
    * Funksjonen går gjennom hver bokstav i "message" og popper de inn i 
    * Text objectet sin text.
    **************************************************************************/
    IEnumerator TypeText()
    {
        foreach (char letter in message)
        {
            textComp.text += letter;               //putter bokstav på skjermen
            yield return 0;                              //Usikker på nødvendig
            yield return new WaitForSeconds(letterPause);            //Ventetid
        }
    }
}