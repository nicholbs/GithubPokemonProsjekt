using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBattleHud : MonoBehaviour
{
    public Text nameText;
    public Text catchPhrase;


    public void SetHud(Unit unit)
    {
        nameText.text = unit.unitName;
        catchPhrase.text = unit.catchPhrase;
    }
}
