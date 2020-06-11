using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;          //Nødvendig å inkludere for UI objektet "Slider"
public class BattleHud : MonoBehaviour
{
    public Text nameText;       //variabel for "Name", bruk Text_Name som param
    public Text levelText;      //variabel for "Lvl", bruk Text_Level som param
    public Slider hpSlider; //variabel for Health slider, bruk Slider som param
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
        hpSlider.maxValue = unit.maxHP; //Oppdaterer health slideren sin MaxHp
        hpSlider.value = unit.currentHP;//Oppdaterer health slider verdi på ...
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


}
