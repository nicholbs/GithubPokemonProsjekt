using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]                           //Betyr at vi kan lagre som fil
public class EnemyData
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
    //>Dataen som er tilgjengelig for oss å lagre til fil

    /**********************************************************************//**
    * Funksjon for å hente inn Data fra en Unit, nemlig enemy.
    * 
    * Funksjonen henter ut dataen assosiert med en Enemy.
    * @param Script_Unit enemy - medsendt Unit (enemy) vi henter data fra
    **************************************************************************/
    public EnemyData(Unit enemy)
    {
        unitName = enemy.unitName;
        unitCatchPhrase = enemy.catchPhrase;

        level = enemy.unitLevel;
        damage = enemy.damage;

        maxHealth = enemy.maxHP;
        currentHP = enemy.currentHP;

        unitHealing = enemy.healingAmount;

        currentXP = enemy.currentEXP;
        maxXP = enemy.maxEXP;

        xpGivenIfDeafeted = enemy.xpToGiveIfDefeated;
    }
}
