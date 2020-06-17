using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class Unit : MonoBehaviour
{
    public string unitName;
    public string catchPhrase;

    public int unitLevel;
    public int damage;
    public int maxHP;
    public int currentHP;
    public int healingAmount;

    public float currentEXP;
    public float maxEXP;
    public float xpToGiveIfDefeated;
    //>Variabler som definerer en Unit

    /**********************************************************************//**
    * Funksjon for å sjekke om Unit har gått opp i lvl
    * 
    * @param int xp - mengde xp fått fra kamp
    * @return bool - true eller false om Unit nådd grense (maxEXP) for å lvle
    **************************************************************************/
    public float LevelUpCheck(float xp)
    {
        for (int i = 0; i < xp; i++)
        {
        currentEXP += 1;

            if (currentEXP >= maxEXP)
            {
                float differanseIMaxXP = 10f;
                unitLevel += 1;
                currentEXP -= maxEXP;
                maxEXP += maxEXP / differanseIMaxXP;

            }
            
        }
        return currentEXP;
    }
    /**********************************************************************//**
    * Funksjon for å oppdatere Unit hp og sjekke om dmg tatt gjør hp til null.
    * 
    * @param int dmg - motstander sin dmg
    * @return bool - true eller false om Unit har null liv etter tatt dmg.
    **************************************************************************/
    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;

        if (currentHP <= 0)
            return true;
        else
            return false;
    }
    /**********************************************************************//**
    * Funksjon for å heale Unit med medsendt mengde. 
    * 
    * Setter hp til max om overheal.
    * @param int amount - mengde Unit skal heales
    **************************************************************************/
    public void Heal(int amount)
    {
        currentHP += amount;
        if (currentHP > maxHP)
            currentHP = maxHP;
    }

    /**********************************************************************//**
    * Funksjon for å Save en Unit, nemlig player. Brukt i "Save" knapper
    *
    * @see Script_saveSystem.SavePlayer(Script_Unit) - Unit (player) som lagres
    **************************************************************************/
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }



    /**********************************************************************//**
    * Funksjon for å "Loading" av Unit, nemlig player. Brukt i "Load" knapper
    *
    * @see Script_saveSystem.LoadPlayer() - Unit (player) som lagres
    **************************************************************************/
    public void LoadPlayer(GameObject Player_Pos)
    {
        PlayerData data = SaveSystem.LoadPlayer();
        unitName = data.unitName;
        catchPhrase = data.unitCatchPhrase;

        unitLevel = data.level;
        damage = data.level;

        currentHP = data.currentHP;
        maxHP = data.maxHealth;

        healingAmount = data.unitHealing;

        currentEXP = data.currentXP;
        maxEXP = data.maxXP;
        xpToGiveIfDefeated = data.xpGivenIfDeafeted;


        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];



        Player_Pos.GetComponent<Transform>().position = position;
        transform.position = position;


        /*
         * Oppdaterer valgt player prefab nedenfor
         */

        GameObject playerPrefab = Resources.Load<GameObject>(
                                                 StaticClass.NamePlayerPrefab);


        playerPrefab.GetComponent<Unit>().unitName = data.unitName;
        playerPrefab.GetComponent<Unit>().catchPhrase = data.unitCatchPhrase;

        playerPrefab.GetComponent<Unit>().unitLevel = data.level;
        playerPrefab.GetComponent<Unit>().damage = data.damage;

        playerPrefab.GetComponent<Unit>().maxHP = data.maxHealth;
        playerPrefab.GetComponent<Unit>().currentHP = data.currentHP;

        playerPrefab.GetComponent<Unit>().healingAmount = data.unitHealing;

        playerPrefab.GetComponent<Unit>().currentEXP = data.currentXP;
        playerPrefab.GetComponent<Unit>().maxEXP = data.maxXP;
        playerPrefab.GetComponent<Unit>().xpToGiveIfDefeated =
                                                        data.xpGivenIfDeafeted;


        playerPrefab.GetComponent<Transform>().position = position;
        playerPrefab.GetComponent<Transform>().Find(
                                             "Player_Pos").position = position;




    }


    /**********************************************************************//**
    * Funksjon for å Save en Unit, nemlig enemy.
    *
    * @see Script_saveSystem.SaveEnemy(Script_Unit) - Unit (enemy) som lagres
    **************************************************************************/
    public void SaveEnemy()
    {
        SaveSystem.SaveEnemy(this);
    }

    /**********************************************************************//**
    * Funksjon for "Loading" av en Unit, nemlig enemy.
    *
    * @see Script_saveSystem.LoadEnemy(Script_Unit) - Unit (enemy) som lagres
    **************************************************************************/
    public void LoadEnemy()
    {
        EnemyData data = SaveSystem.LoadEnemy();
        unitLevel = data.level;
        currentHP = data.health;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }

}
