using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]                           //Betyr at vi kan lagre som fil
public class PlayerData
{
    public int level;
    public int health;
    public float xp;
    public float[] position;
    public float xpGivenIfDeafeted;
    //>Dataen som er tilgjengelig for oss å lagre til fil


    /**********************************************************************//**
    * Funksjon for å hente inn Data fra en Unit, nemlig player.
    * 
    * Funksjonen henter ut dataen assosiert med en Player.
    * @param Script_Unit player - medsendt Unit (player) vi henter data fra
    **************************************************************************/
    public PlayerData (Unit player) {
        level = player.unitLevel;
        health = player.currentHP;
        xp = player.currentEXP;
        xpGivenIfDeafeted = player.xpToGiveIfDefeated;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
