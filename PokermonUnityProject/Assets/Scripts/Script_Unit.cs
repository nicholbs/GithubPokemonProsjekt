using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Unit : MonoBehaviour
{
    public string unitName;
    public int unitLevel;
    public int damage;
    public int maxHP;
    public int currentHP;
    public int healingAmount;
    //>Variabler som definerer en Unit

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

}
