using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject currentInterObject = null;           //objectet i "Fokus"


    /**********************************************************************//**
    * Funksjon som blir kalt 50 ish ganger hver frame.
    *
    * Antall ganger tilkalt er dynamisk og avhenger av frameRate. Er derfor
    * ypperlig for å hente inn input fra brukeren.
    * Funksjonen sjekker om spilleren har trykket knappen avsatt på "interact"
    * i "Input manager". Knappen kan endres ved Edit -> Project Settings ->
    * Input Manager -> interact.
    * Dersom spiller trykket "interact" knappen blir funksjonen sendt med som
    * parameter i currentInterObject.SendMessage() kalt.
    * 
    * NB! Dette er en "Legacy" løsning på input i Unity. Det har blitt
    * introdusert et nyere system, nemlig "Input System" som skal ifølge devs
    * gjøre det sømfritt å ha forskjellige systemer og deres input kunne tolkes
    * likt i spillet. For eksempel dersom du kjører spillet og i midten av
    * spillet plugger i game controller kan det være per nå at det ikke blir
    * detektert!
    **************************************************************************/
    private void Update()
    {
        /*
         * Dersom spilleren trykket "interact" knappen og spiller har fokus
         * på et object
         */
        if (Input.GetButtonDown("interact") && currentInterObject)
        {
            currentInterObject.SendMessage("DoInteraction");
          //>Tilkall funksjonen med navnet lik det sendt som param til objectet
        }
            
    }

    /**********************************************************************//**
    * Funksjon blir kalt når festet object sin collider2d treffer annen object
    * sin collider2d.
    * 
    * Funksjonen kalles når dette objectet sin collider2D treffer annen object
    * sin collider2D. 
    * Funksjonen sjekker om objectet truffet har taggen "interObject".
    * Funksjonen setter deretter objectet som ble kollidert med lik variabel,
    * og skaper sånn sett effekten av å ha et object som "fokus".
    * Altså, når spilleren går innenfor sonen til et object med egen collider
    * blir det objectet satt som spilleren sin "fokus".
    * 
    * @param Collider2D other - objectet som spiller kolliderte med.
    **************************************************************************/
    void OnTriggerEnter2D(Collider2D other)
    {
         //Dersom objectet du kolliderte med har taggen lik det sendt som param
        if (other.CompareTag("interObject"))
        {
            Debug.Log(other.name); //ny entry i Debug logg, kollidert sitt navn
            currentInterObject = other.gameObject;   //Setter kollidert i focus
        }
    }

    /**********************************************************************//**
    * Funksjon blir kalt når festet object sin collider2d forlater annen object
    * sin collider2d.
    * 
    * Funksjonen kalles når dette objectet sin collider2D forlater annen object
    * sin collider2D. 
    * Funksjonen sjekker om objectet som spilleren "forlot" sin sone, har
    * taggen "interObject". Dersom objectet hadde taggen settes deretter 
    * variabelen brukt for å holde "fokus" til null. Skaper effekten av å miste
    * "fokus" på object.
    **************************************************************************/
    private void OnTriggerExit2D(Collider2D collision)
    {
               //Sjekker om objectet som spiller forlot hadde tag "interObject"
        if (collision.CompareTag("interObject"))
        {
            if (collision.gameObject == currentInterObject)
                                //>Dersom objectet forlatt var objectet i fokus
            {
                currentInterObject = null;       //Sett object i fokus til null
            }
        }
    }

}
