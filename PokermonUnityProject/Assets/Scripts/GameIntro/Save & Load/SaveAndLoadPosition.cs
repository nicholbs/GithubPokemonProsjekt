using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoadPosition : MonoBehaviour
{
    private readonly GameObject player;
    public Unit playerPreFab;     //variabel for prefab, template for spilleren

    /**********************************************************************//**
    * Funksjon som blir kalt en gang og før alle andre frames.
    *
    * Antall ganger tilkalt er statisk og en gang.
    * Funksjonen setter spiller sin posisjon lik spilleren sin preFab
    * NB! Kan være dette er en dust måte å hente inn posisjon til spiller fra
    * "fil" til posisjonen spilleren har i selve spillet.
    **************************************************************************/
    private void Start()
    {




        //player.GetComponent<Transform>().position = 
        //                       playerPreFab.GetComponent<Transform>().position;
    }

    /**********************************************************************//**
    * Funksjon oppdaterer spilleren sin prefab med spilleren sine data.
    *
    * Funksjonen setter verdiene i Unit player (prefab) lik data i GameObject
    * player sin Unit. Altså spilleren har en komponent av typen Unit som
    * oppdateres under spilletid.
    * NB! Kan være dette er en dust måte å gjøre lagring til "fil" ettersom 
    * Unit har en funksjon "SavePlayer" som lagrer data i Unit player (prefab)
    * til fil. For eksempel kunne vi ha hatt en fil som er prefab og en annen
    * fil som lagrer data under spilletid, men slik det er satt opp nå blir
    * data oppdatert og kan hentes felles mellom alle scener ved å alltid bruke
    * Unit player sine dataer.
    **************************************************************************/
    public void SavePositionPlayer()
    {


        playerPreFab.GetComponent<Transform>().position =
                                     player.GetComponent<Transform>().position;

        playerPreFab.GetComponent<Unit>().unitName =
                                          player.GetComponent<Unit>().unitName;

        playerPreFab.GetComponent<Unit>().unitLevel =
                                         player.GetComponent<Unit>().unitLevel;

        playerPreFab.GetComponent<Unit>().damage =
                                            player.GetComponent<Unit>().damage;

        playerPreFab.GetComponent<Unit>().maxHP =
                                             player.GetComponent<Unit>().maxHP;

        playerPreFab.GetComponent<Unit>().currentHP =
                                         player.GetComponent<Unit>().currentHP;

        playerPreFab.GetComponent<Unit>().healingAmount =
                                     player.GetComponent<Unit>().healingAmount;




    }
}
