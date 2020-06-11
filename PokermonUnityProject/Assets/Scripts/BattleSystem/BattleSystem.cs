using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEditor.Build.Player;
using UnityEngine;
using UnityEngine.UI;                            //Nødvendig for UI object Text 

public enum BattleState {START, PLAYERTURN, ENEMYTURN, WON, LOST }
        //>variabel BattleState for å representere hvilken "State" spillet er i
  
public class BattleSystem : MonoBehaviour
{
    public BattleState state;  //Variabel for "State" i GameObject_BattleSystem

    public GameObject playerPrefab;//variabel for Unit, bruk "Player" som param
    public GameObject enemyPrefab;  //variabel for Unit, bruk "Enemy" som param
    //>Prefab betyr "ferdigstilt", altså ferdigstilte GameObject 

    public Transform playerBattleStation;  
                   //>variabel for pos til battleStation hvor "Player" skal stå
    public Transform enemyBattleStation;
                    //>variabel for pos til battleStation hvor "Enemy" skal stå

    Unit playerUnit;                //variabel for Unit, put "Player" som param
    Unit enemyUnit;                  //variabel for Unit, put "Enemy" som param

    public Text dialogueText;           //variabel for Text i Image_dialogueBox


    public BattleHud playerHUD;    //variabel for BattleHud til "Player"
    public BattleHud enemyHUD;      //variabel for BattleHud til "Enemy"


    Vector3 gammelPos;
  
 
    /**********************************************************************//**
    * Funksjon som blir kalt før første frame oppdateringen, altså med en gang.
    **************************************************************************/
    void Start()
    {
    gammelPos = playerPrefab.GetComponent<Transform>().position;
        /*
         * Lagrer posisjonen til player slik at vi kan nullstille pos i battle
         * slik at spilleren sin sprite blir riktig plassert på battleStation
         * Så når kampen er over blir pos tilbake til gammelPos
         */
        state = BattleState.START;                //BattleState starter i START
        StartCoroutine(SetupBattle());//For å lage ventetid bruker vi Coroutine
        //>Coroutine kjører seperat fra alt annet og lar oss pause når vi vil.
     //>For å kalle på en Coroutine må vi legge StartCoroutine(funksjonNavn());
    }


    /**********************************************************************//**
    * Funksjon for å gjøre klar kampen. Oppdatere Hud, legge til Spillere.. osv
    * 
    * Funksjonen starter med at du ser "Player" og "Enemy" på sine 
    * BattleStation og det er ønskelig før kampen starter at du får innledende
    * tekst. Funksjonen er derfor gjort om til en Coroutine. For å gjøre om til
    * Coroutine bytter vi "returnType" med "IEnumerator". Da kan vi bruke:
    *       yield return new WaitForSeconds(float ventetidISekunder);
    * @see void Script_BattleHud.SetHud(Unit unit)-oppdatere tekst på BattleHud
    * @see void Script_BattleSystem.PlayerTurn() - oppdaterer Image_dialogueBox
    **************************************************************************/
    IEnumerator SetupBattle()
{
        playerPrefab.GetComponent<Transform>().position = new Vector3(0, 0, 0);
        /*
         * Gjør midlertidig posisjonen til spilleren lik x=0, y=0 og z=0
         * slik at spilleren sin sprite blir riktig plassert på battleStation
         * NB! sier aldri delete, kan dette bli minne lekasje? ser ut til at
         * C# har garbage collection som forhindrer slike problemer i
         * motsetning til C og C++
         */
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        
        //>Instantiate kopierer ett objekt og kan overloades med ny pos
           //>Lager GameObject lik "Unit" (Player) og med pos til BattleStation

        playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();
        //>Instantiate kopierer ett objekt og kan overloades med ny pos
            //>Lager GameObject lik "Unit" (Enemy) og med pos til BattleStation


        dialogueText.text = "A wild " + enemyUnit.unitName + " approaches...";
       //>Setter teksten i Image_DialogueBox til "A wild ..., altså intro tekst

        playerHUD.SetHud(playerUnit);  //Oppdaterer "Player" sin BattleHud info
        enemyHUD.SetHud(enemyUnit);     //Oppdaterer "Enemy" sin BattleHud info

        yield return new WaitForSeconds(1f);      //Venter i 1 sekund for intro

        state = BattleState.PLAYERTURN;                        //Player sin tur
        PlayerTurn();                  //Oppdaterer Image_DialogueBox sin tekst

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
            EndBattle();         //Sjekker state, Image_DialogueBox sier vunnet
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
            EndBattle();           //Sjekker state, Image_DialogueBox sier tapt

        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();              //Oppdaterer Image_DialogueBox sin tekst
        }


    }



    /**********************************************************************//**
    * Funksjon for å oppdatere Image_DialogueBox med ny tekst
    **************************************************************************/
    void PlayerTurn()
    {
        dialogueText.text = "Choose an action:";
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
            OppdaterPreFab();           //Oppdaterer all data fra kampen til prefab
           
            
        }
        else if (state == BattleState.LOST)
        {
            dialogueText.text = "You are defeated!";
            enemyHUD.SetXp(playerUnit.xpToGiveIfDefeated);
             OppdaterPreFab();           //Oppdaterer all data fra kampen til prefab
        }
    }


 



    /**********************************************************************//**
    * Funksjon for å oppdatere prefab sine data med nye verdier etter kamp
    **************************************************************************/
    public void OppdaterPreFab()
    {
        playerPrefab.GetComponent<Unit>().currentEXP =
                                          playerUnit.currentEXP;      //unitLevel
        playerPrefab.GetComponent<Unit>().maxEXP =
                                         playerUnit.maxEXP;      //unitLevel

        playerPrefab.GetComponent<Transform>().position = gammelPos;
        /*
         * Gjør posisjonen til spilleren tilbake til pos den hadde i selve
         * spillet fra den nullstilte posisjonen som er nødvendig i battle
         */

        playerPrefab.GetComponent<Unit>().unitLevel =
                                         playerUnit.unitLevel;      //unitLevel

        playerPrefab.GetComponent<Unit>().damage =
                                            playerUnit.damage;         //damage

        playerPrefab.GetComponent<Unit>().maxHP =
                                             playerUnit.maxHP;          //maxHP

        playerPrefab.GetComponent<Unit>().currentHP =
                                         playerUnit.currentHP;      //CurrentHP

        playerPrefab.GetComponent<Unit>().healingAmount =
                                     playerUnit.healingAmount;  //healingAmount
        /*
         * Oppdaterer verdiene til spilleren med unit playerUnit sin data fra
         * kampen slik at spilleren blir i annen scene også er oppdatert.
         */
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

}