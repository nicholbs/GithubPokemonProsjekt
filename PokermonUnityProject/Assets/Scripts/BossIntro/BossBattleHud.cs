using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBattleHud : MonoBehaviour
{
    public Text nameText;     //Text object som skal få sin tekst lik boss navn
    public Text catchPhrase;       //Text object blir lik boss sitt catchPhrase

    /**********************************************************************//**
    * Funksjon for å gjøre Text object sin text lik boss navn og catchPhrase
    **************************************************************************/
    public void SetHud(Unit unit)
    {
        nameText.text = unit.unitName;
        catchPhrase.text = unit.catchPhrase;
    }
}
