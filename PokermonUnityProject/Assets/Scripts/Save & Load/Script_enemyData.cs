using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]                           //Betyr at vi kan lagre som fil
public class Script_enemyData
{
    public int level;
    public int health;
    public float[] position;
                          //>Dataen som er tilgjengelig for oss å lagre til fil
   
    /**********************************************************************//**
    * Funksjon for å hente inn Data fra en Unit, nemlig enemy.
    * 
    * Funksjonen henter ut dataen assosiert med en Enemy.
    * @param Script_Unit enemy - medsendt Unit (enemy) vi henter data fra
    **************************************************************************/
    public Script_enemyData(Script_Unit enemy)
    {
        level = enemy.unitLevel;
        health = enemy.currentHP;

        position = new float[3];
        position[0] = enemy.transform.position.x;
        position[1] = enemy.transform.position.y;
        position[2] = enemy.transform.position.z;
    }
}
