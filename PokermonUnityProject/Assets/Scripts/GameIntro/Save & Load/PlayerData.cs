using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]                           //Betyr at vi kan lagre som fil
public class PlayerData
{
    public string unitName;
    public string unitCatchPhrase;

    public int level;
    public int damage;

    public int maxHealth;
    public int currentHP;

    public int unitHealing;

    public float currentXP;
    public float maxXP;

    public float xpGivenIfDeafeted;

    public float[] position;
    //>Dataen som er tilgjengelig for oss å lagre til fil


    /**********************************************************************//**
    * Funksjon for å hente inn Data fra en Unit, nemlig player.
    * 
    * Funksjonen henter ut dataen assosiert med en Player.
    * @param Script_Unit player - medsendt Unit (player) vi henter data fra
    **************************************************************************/
    public PlayerData (Unit player) {
        unitName = player.unitName;
        unitCatchPhrase = player.catchPhrase;

        level = player.unitLevel;
        damage = player.damage;

        maxHealth = player.maxHP;
        currentHP = player.currentHP;

        unitHealing = player.healingAmount;

        currentXP = player.currentEXP;
        maxXP = player.maxEXP;

        xpGivenIfDeafeted = player.xpToGiveIfDefeated;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
