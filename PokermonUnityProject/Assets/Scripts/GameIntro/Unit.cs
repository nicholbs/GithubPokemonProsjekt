using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using UnityEngine;


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
        currentEXP++;

            if (currentEXP >= maxEXP)
            {
                float differanseIMaxXP = 10f;
                unitLevel++;
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
        PlayerData player = new PlayerData(this);

        SaveSystem.SaveUnitPlayerData(Application.persistentDataPath + StaticClass.PlayerFilePath, player);
    }

    /**********************************************************************//**
    * Funksjon for å Save en Unit, nemlig player. Brukt i "Save" knapper
    *
    * @see Script_saveSystem.SavePlayer(Script_Unit) - Unit (player) som lagres
    **************************************************************************/
    public void SavePlayerAuto()
    {
        PlayerData player = new PlayerData(this);
        SaveSystem.SaveUnitPlayerData(Application.persistentDataPath + StaticClass.AutoSavePathPlayer, player);
        //StaticClass.AutoSaveAmountPlayer++;
        //Debug.Log(StaticClass.AutoSaveAmountPlayer);
    }



    /**********************************************************************//**
    * Funksjon for å "Loading" av Unit, nemlig player. Brukt i "Load" knapper
    *
    * @see Script_saveSystem.LoadPlayer() - Unit (player) som lagres
    **************************************************************************/
    public void LoadPlayer() 
    {
        PlayerData unitFrafil = SaveSystem.ReadFromBinaryFile(Application.persistentDataPath + StaticClass.PlayerFilePath);
        this.unitName = unitFrafil.unitName;
        this.catchPhrase = unitFrafil.unitCatchPhrase;

        this.unitLevel = unitFrafil.level;
        this.damage = unitFrafil.damage;

        this.maxHP = unitFrafil.maxHealth;
        this.currentHP = unitFrafil.currentHP;

        this.currentEXP = unitFrafil.currentXP;
        this.maxEXP = unitFrafil.maxXP;

        this.xpToGiveIfDefeated = unitFrafil.xpGivenIfDeafeted;
    }


    /**********************************************************************//**
    * Funksjon for å "Loading" av Unit, nemlig player. Brukt i "Load" knapper
    *
    * @see Script_saveSystem.LoadPlayer() - Unit (player) som lagres
    **************************************************************************/
    public void LoadPlayerAuto()
    {
        PlayerData unitFrafil = SaveSystem.ReadFromBinaryFile(Application.persistentDataPath + StaticClass.AutoSavePathPlayer);
        this.unitName = unitFrafil.unitName;
        this.catchPhrase = unitFrafil.unitCatchPhrase;

        this.unitLevel = unitFrafil.level;
        this.damage = unitFrafil.damage;

        this.maxHP = unitFrafil.maxHealth;
        this.currentHP = unitFrafil.currentHP;

        this.currentEXP = unitFrafil.currentXP;
        this.maxEXP = unitFrafil.maxXP;

        this.xpToGiveIfDefeated = unitFrafil.xpGivenIfDeafeted;
    }



    /**********************************************************************//**
    * Funksjon for å Save en Unit, nemlig enemy.
    *
    * @see Script_saveSystem.SaveEnemy(Script_Unit) - Unit (enemy) som lagres
    **************************************************************************/
    public void SaveEnemyAuto()
    {
        PlayerData enemy = new PlayerData(this);
        SaveSystem.SaveUnitPlayerData(Application.persistentDataPath + StaticClass.AutoSavePathEnemy, enemy);
        
    }


    /**********************************************************************//**
    * Funksjon for å Save en Unit, nemlig enemy.
    *
    * @see Script_saveSystem.SaveEnemy(Script_Unit) - Unit (enemy) som lagres
    **************************************************************************/
    public void SaveEnemy()
    {
        PlayerData enemy = new PlayerData(this);

        SaveSystem.SaveUnitPlayerData(Application.persistentDataPath + StaticClass.EnemyFilePath, enemy);
    }


    /**********************************************************************//**
    * Funksjon for "Loading" av en Unit, nemlig enemy.
    *
    * @see Script_saveSystem.LoadEnemy(Script_Unit) - Unit (enemy) som lagres
    **************************************************************************/
    public void LoadEnemy()
    {
        PlayerData unitFrafil = SaveSystem.ReadFromBinaryFile(Application.persistentDataPath + StaticClass.EnemyFilePath);
        this.unitName = unitFrafil.unitName;
        this.catchPhrase = unitFrafil.unitCatchPhrase;

        this.unitLevel = unitFrafil.level;
        this.damage = unitFrafil.damage;

        this.maxHP = unitFrafil.maxHealth;
        this.currentHP = unitFrafil.currentHP;

        this.currentEXP = unitFrafil.currentXP;
        this.maxEXP = unitFrafil.maxXP;

        this.xpToGiveIfDefeated = unitFrafil.xpGivenIfDeafeted;
    }



    /**********************************************************************//**
  * Funksjon for "Loading" av en Unit, nemlig enemy.
  *
  * @see Script_saveSystem.LoadEnemy(Script_Unit) - Unit (enemy) som lagres
  **************************************************************************/
    public void LoadEnemyAuto()
    {
        PlayerData unitFrafil = SaveSystem.ReadFromBinaryFile(Application.persistentDataPath + StaticClass.AutoSavePathEnemy);
        this.unitName = unitFrafil.unitName;
        this.catchPhrase = unitFrafil.unitCatchPhrase;

        this.unitLevel = unitFrafil.level;
        this.damage = unitFrafil.damage;

        this.maxHP = unitFrafil.maxHealth;
        this.currentHP = unitFrafil.currentHP;

        this.currentEXP = unitFrafil.currentXP;
        this.maxEXP = unitFrafil.maxXP;

        this.xpToGiveIfDefeated = unitFrafil.xpGivenIfDeafeted;
    }


    /**********************************************************************//**
    * Funksjon for "Loading" av en Unit, nemlig enemy.
    *
    * @see Script_saveSystem.LoadEnemy(Script_Unit) - Unit (enemy) som lagres
    **************************************************************************/
    public void DeleteAutoSaveEnemy()
    {
        if (File.Exists(Application.persistentDataPath + StaticClass.AutoSavePathEnemy))
        File.Delete(Application.persistentDataPath + StaticClass.AutoSavePathEnemy);
    }

    /**********************************************************************//**
  * Funksjon for "Loading" av en Unit, nemlig enemy.
  *
  * @see Script_saveSystem.LoadEnemy(Script_Unit) - Unit (enemy) som lagres
  **************************************************************************/
    public void DeleteAutoSavePlayer()
    {
        if (File.Exists(Application.persistentDataPath + StaticClass.AutoSavePathPlayer))
            File.Delete(Application.persistentDataPath + StaticClass.AutoSavePathPlayer);
    }


}
