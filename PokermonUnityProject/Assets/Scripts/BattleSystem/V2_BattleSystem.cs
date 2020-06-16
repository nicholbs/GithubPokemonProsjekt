using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.UI;                            //Nødvendig for UI object Text 
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }
        //>variabel BattleState for å representere hvilken "State" spillet er i

public class V2_BattleSystem : MonoBehaviour
{
    public BattleState state;  //Variabel for "State" i GameObject_BattleSystem

    public GameObject playerPrefab;//variabel for Unit, bruk "Player" som param
    public GameObject enemyPrefab;  //variabel for Unit, bruk "Enemy" som param

    public Transform playerPos;
                   //>variabel for pos til battleStation hvor "Player" skal stå
    public Transform enemyPos;
                    //>variabel for pos til battleStation hvor "Enemy" skal stå

        Unit playerUnit;            //variabel for Unit, put "Player" som param
        Unit enemyUnit;              //variabel for Unit, put "Enemy" som param

    public Text dialogueText;           //variabel for Text i Image_dialogueBox
   
    public BattleHud playerHUD;           //variabel for BattleHud til "Player"
    public BattleHud enemyHUD;             //variabel for BattleHud til "Enemy"


    GameObject player;
          //>Variabel for spiller som blir "instantiatet" i scene under runtime
    GameObject boss;
    //>Variabel for Boss som blir "instantiatet" i scene under runtime

    public string sceneToLoad = null;


    /**********************************************************************//**
    * Funksjon som blir kalt før første frame oppdateringen, altså med en gang.
    **************************************************************************/
    void Start()
    {
        state = BattleState.START;                //BattleState starter i START
        StartCoroutine(SetupBattle());//For å lage ventetid bruker vi Coroutine
    }


    /**********************************************************************//**
    * Funksjon for å gjøre klar kampen. Oppdatere Hud, legge til Spillere.. osv
    * 
    * Funksjon har ventetid og er derfor Coroutine.
    * Funksjonen oppretter to objecter (enemy og spiller) under "runtime" som
    * blir plassert på battle stasjonene med oppdatert info på hver sin HUD.
    * Funksjonen gjør det deretter til spilleren sin tur.
    *
    * @see void Script_BattleHud.SetHud(Unit unit)-oppdatere tekst på BattleHud
    * @see void Script_BattleSystem.PlayerTurn() - oppdaterer Image_dialogueBox
    **************************************************************************/
    IEnumerator SetupBattle()
    {
        player = Instantiate(playerPrefab, playerPos);
        boss = Instantiate(enemyPrefab, enemyPos);
        /*
        * Lager player og boss objecter "under" 
        * runtime utifra prefab og med ny pos fra andre parameter
        */
        playerUnit = player.GetComponent<Unit>();
        enemyUnit = boss.GetComponent<Unit>();

        player.GetComponent<Playermovesin>().enabled = true;
        dialogueText.text = "A wild " + enemyUnit.unitName + " approaches...";
       //>Setter teksten i Image_DialogueBox til "A wild ..., altså intro tekst

        playerHUD.SetHud(playerUnit);  //Oppdaterer "Player" sin BattleHud info
        enemyHUD.SetHud(enemyUnit);     //Oppdaterer "Enemy" sin BattleHud info

        yield return new WaitForSeconds(2f);      //Venter i 1 sekund for intro

        state = BattleState.PLAYERTURN;                        //Player sin tur
        PlayerTurn();                  //Oppdaterer Image_DialogueBox sin tekst
    }

    /**********************************************************************//**
    * Funksjon for å oppdatere Image_DialogueBox med ny tekst
    **************************************************************************/
    void PlayerTurn()
    {
        dialogueText.text = "Choose an action:";
    }


    /**********************************************************************//**
    * Funksjon for angrep til "Player", Player vinner eller Enemy får sin tur.
    * 
    * Funksjonen sjekker om "Enemy" dør av å ta "Player" sin damage. 
    * Funksjon har ventetid og er derfor Coroutine.
    * Funksjon oppdaterer BattleState til Won om "Enemy" dør eller til Enemy
    * sin tur dersom ikke.
    * 
    * @see Unit.TakeDamage(int dmg) - sjekker om "Unit" sin hp blir 0 etter dmg
    * @see void Script_BattleHud.SetHp(int hp) - oppdater BattleHud health
    * @see IEnumerator Script_BattleSystem.EnemyTurn() - nesten identisk...
    **************************************************************************/
    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
        //>Sjekker om "Enemy" dør av "Player" sitt angrep

        enemyHUD.SetHp(enemyUnit.currentHP);
        //>oppdaterer health slider på BattleHud
        dialogueText.text = "The attack is successful!";           //Veiledende


        yield return new WaitForSeconds(0.5f);          //Venter i 0.5 sekunder

        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();         //Sjekker state, Image_DialogueBox sier vunnet           AvKommenter
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());   //Nesten identisk til PlayerAttack()
        }

    }


    /**********************************************************************//**
    * Funksjon for å heale "Player". Oppdaterer Image_DialogueBox og Enemy tur.
    * 
    * Funksjonen healer "Player".
    * Oppdaterer Image_DialogueBox.
    * Funksjon har ventetid og er derfor Coroutine.
    * Funksjon oppdaterer BattleState til ENEMYTURN.
    * 
    * @see void Unit.Heal(int amount) - healer player basert på healingAmount
    * @see void Script_BattleHud.SetHp(int hp) - oppdater BattleHud health
    * @see IEnumerator Script_BattleSystem.EnemyTurn() - Enemy sin tur, angripe
    **************************************************************************/
    IEnumerator PlayerHeal()
    {
        playerUnit.Heal(playerUnit.healingAmount);
        //healer basert på healingAmount

        playerHUD.SetHp(playerUnit.currentHP); //Oppdaterer Player BattleHud hp
        dialogueText.text = "You feel renewed strenght!";          //Veiledende

        yield return new WaitForSeconds(0.5f);               //Venter i 0.5 sek

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());                            //Enemy sin tur
    }



    /**********************************************************************//**
    * Funksjon for angrep til "Enemy", Enemy vinner eller Player får sin tur.
    * 
    * Funksjonen sjekker om "Player" dør av å ta "Enemy" sin damage. 
    * Funksjon har ventetid og er derfor Coroutine.
    * Funksjon oppdaterer BattleState til Won om "Player" dør eller til Player
    * sin tur dersom ikke.
    * 
    * @see Unit.TakeDamage(int dmg) - sjekker om "Unit" sin hp blir 0 etter dmg
    * @see void Script_BattleHud.SetHp(int hp) - oppdater BattleHud health
    * @see void Script_BattleSystem.PlayerTurn() - oppdaterer Image_DialogueBox
    **************************************************************************/
    IEnumerator EnemyTurn()
    {
        dialogueText.text = enemyUnit.unitName + " attacks!";      //Veiledende

        yield return new WaitForSeconds(0.5f);          //Venter i 0.5 sekunder

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);
        //>Sjekker om "Player" dør av "Enemy" sitt angrep
        playerHUD.SetHp(playerUnit.currentHP);
        //>oppdaterer health slider på BattleHud

        yield return new WaitForSeconds(1f);//Venter i to sekunder før ny state
        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();           //Sjekker state, Image_DialogueBox sier tapt           AvKommenter

        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();              //Oppdaterer Image_DialogueBox sin tekst
        }


    }

    /**********************************************************************//**
    * Funksjon brukt i "Attack" knappen. Sjekker state, angriper om riktig.
    * 
    * Funksjonen kan bli gitt til en knapp og brukes "on Click()". Når spiller
    * klikker på knappen blir funksjonen "tilkalt".
    * Funksjonen er brukt i Button_Attack i Image_DialogueBox og sjekker om
    * det er "Player" sin tur, dersom riktig angripes "Enemy".
    * @see IEnumerator Script_BattleSystem.PlayerAttack() - angriper "Enemy"
    **************************************************************************/
    public void OnattackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
    }

    /**********************************************************************//**
    * Funksjon brukt i "Heal" knappen. Sjekker state, healer om riktig.
    * 
    * Funksjonen kan bli gitt til en knapp og brukes "on Click()". Når spiller
    * klikker på knappen blir funksjonen "tilkalt".
    * Funksjonen er brukt i Button_Heal i Image_DialogueBox og sjekker om
    * det er "Player" sin tur, dersom riktig heales "Player".
    * @see IEnumerator Script_BattleSystem.PlayerHeal() - healer "Player"
    **************************************************************************/
    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());
    }


    /**********************************************************************//**
    * Funksjon for å oppdatere Image_DialogueBox basert på state med ny tekst
    **************************************************************************/
    void EndBattle()
    {

        if (state == BattleState.WON)
        {
            dialogueText.text = "You won the battle!";
            //Unit temp =
            playerHUD.SetXp(enemyUnit.xpToGiveIfDefeated);                      //oppdater xpslider
            playerUnit.currentEXP = playerUnit.LevelUpCheck(enemyUnit.xpToGiveIfDefeated);
            //playerPrefab.GetComponent<Unit>().currentEXP = temp.currentEXP;
            //playerPrefab.GetComponent<Unit>().maxEXP = temp.maxEXP;
            //OppdaterPreFab();           //Oppdaterer all data fra kampen til prefab           Avkommenter meg
           
            
        }
        else if (state == BattleState.LOST)
        {
            dialogueText.text = "You are defeated!";
            enemyHUD.SetXp(playerUnit.xpToGiveIfDefeated);
             //OppdaterPreFab();           //Oppdaterer all data fra kampen til prefab          Avkommenter meg
        }
        StartCoroutine(GoToOverworld());
    
    }



    IEnumerator GoToOverworld()
    {
        if (sceneToLoad != null)
        {
            yield return new WaitForSeconds(4f);
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);

            while (!asyncLoad.isDone)
            {
                yield return null;
            }

        }
    }
}
