﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]                           //Betyr at vi kan lagre som fil
public class Script_playerData
{
    public int level;
    public int health;
    public float[] position;
                          //>Dataen som er tilgjengelig for oss å lagre til fil


    /**********************************************************************//**
    * Funksjon for å hente inn Data fra en Unit, nemlig player.
    * 
    * Funksjonen henter ut dataen assosiert med en Player.
    * @param Script_Unit player - medsendt Unit (player) vi henter data fra
    **************************************************************************/
    public Script_playerData (Script_Unit player) {
        level = player.unitLevel;
        health = player.currentHP;
        
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
