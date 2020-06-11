using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]                           //Betyr at vi kan lagre som fil
public class EnemyData
{
    public int level;
    public int health;
    public float xp;
    public float[] position;
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
        level = enemy.unitLevel;
        health = enemy.currentHP;
        xp = enemy.currentEXP;
        xpGivenIfDeafeted = enemy.xpToGiveIfDefeated;

        position = new float[3];
        position[0] = enemy.transform.position.x;
        position[1] = enemy.transform.position.y;
        position[2] = enemy.transform.position.z;
    }
}
