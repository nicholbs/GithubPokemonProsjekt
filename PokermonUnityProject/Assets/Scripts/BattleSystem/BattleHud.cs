﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;          //Nødvendig å inkludere for UI objektet "Slider"
public class BattleHud : MonoBehaviour
{
    public Text nameText;       //variabel for "Name", bruk Text_Name som param
    public Text levelText;      //variabel for "Lvl", bruk Text_Level som param
    public Slider hpSlider; //variabel for Health slider, bruk Slider som param
    public Slider xpSlider;   //variabelen for XP slider, bruk Slider som param
        //>Variabler som du putter diverse objekter fra BattleHud som parameter

    /**********************************************************************//**
    * Funksjon for å oppdatere tekst på BattleHud, tar Unit object som param.
    * 
    * Funksjonen tar inn en Unit som "Player" og oppdaterer variablene ovenfor
    * som "nameText" med Unit sine variabler. For eksempel er BattleHud sin
    * "Text_Name" oppdatert med "Player" sitt navn definert i objektet.
    * 
    * @param Unit unit - Objekt av Unit type som "Player" og "Enemy"
    **************************************************************************/
    public void SetHud(Unit unit)
    {
        nameText.text = unit.unitName;         //Oppdaterer "Name" på BattleHud
        levelText.text = "Lvl " + unit.unitLevel;   //Oppdaterer "Lvl" på ...

        hpSlider.maxValue = unit.maxHP;  //Oppdaterer health slideren sin MaxHp
        hpSlider.minValue = 0;
        hpSlider.value = unit.currentHP;//Oppdaterer health slider verdi på ...

        xpSlider.maxValue = unit.maxEXP;       //Oppdaterer XP slider sin MaxXP
        xpSlider.minValue = 0;
        xpSlider.value = unit.currentEXP;    //Oppdaterer XP slider verdi på ...
    }

    /**********************************************************************//**
    * Funksjon for å oppdatere health slider på BattleHud med Unit sin health.
    * 
    * Funksjonen blir brukt av BattleHud objekter til å oppdatere for eksempel
    * et BattleHudPlayer sitt health slider med verdien av en Unit sin health. 
    * 
    * @param int hp - int fra en Unit som "Player" eller "Enemy"
    **************************************************************************/
    public void SetHp(int hp)
    {
        hpSlider.value = hp;
    }

    /**********************************************************************//**
    * Funksjon for å oppdatere xp slider på BattleHud med medsendt xp.
    * 
    * Funksjonen blir brukt av BattleHud objekter til å oppdatere for eksempel
    * et BattleHudPlayer sitt xp slider med verdien av medsendt xp.
    * Funksjonen bruker en IEnumerator med "kunstig" tid for å simulere at xp
    * baren stiger etter kamp.
    * 
    * @param int xp - int fra en Unit som "Player" eller "Enemy"
    * @see IEnumerator LvlSliderWaitTime(int xp) - for loop oppdaterer xpSlider
    **************************************************************************/
    public IEnumerator SetXP(float xp, int lvl)
    {
        while (xp != 0)
        {
        yield return new WaitForSeconds(0.02f);
            if (xpSlider.value < xpSlider.maxValue)
                xpSlider.value++;
            else if (xpSlider.value == xpSlider.maxValue)
            {
                xpSlider.value = 0;
                lvl++;
                levelText.text = "Lvl " + lvl;
                xpSlider.value++;
                xpSlider.maxValue += 10f;
            }
            xp--;
        }

    }
}
