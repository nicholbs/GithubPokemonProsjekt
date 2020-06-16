using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;      //bruke SceneManagement


public class BossIntroSystem : MonoBehaviour
{
    public GameObject playerPrefab;     //bruk prefab for spiller som parameter
    public GameObject bossPrefab;          //bruk prefab for Boss som parameter

    public Text bossName;           //bruk Text som skal bli lik boss sitt navn
    public Text bossCatchPhrase;
                            //>bruk Text som skal bli lik boss sitt CatchPhrase


    public Transform bossPos;                   //Posisjon Boss skal ha i scene
    public Transform playerPos;               //Posisjon Player skal ha i scene

    public SpriteRenderer bossShadow;          //Bruk boss sin sprite som param

    GameObject player;          
          //>Variabel for spiller som blir "instantiatet" i scene under runtime
    GameObject boss;
             //>Variabel for Boss som blir "instantiatet" i scene under runtime


    public float letterPause = 0.1f;
    //>Tid mellom hver bokstav som popper på skjerm


    public string sceneToLoad = null;

    //Variabler for ReveilSprite()
    public float minimum = 0.0f; //Laveste verdi for farger på en sprite, 0f=0%
    public float maximum = 1f; //Høyeste verdi for farger på en sprite, 1f=100%
    public float duration = 5.0f;        //Mengden tid "Fade-in" transition tar
    private float startTime;            
          //>Sekunder det tok for spillet ble startet til første frame "loadet"
    SpriteRenderer sprite;  //Sprite som skal "Fade-in" fra mørk til lys sprite


    /**********************************************************************//**
    * Funksjon som blir kalt en gang og før alle andre update frames.
    *
    * Antall ganger tilkalt er statisk og en gang.
    * Scriptet i helhet har som hensikt å dynamisk forandre sprite, posisjoner,
    * text og farge (gå fra skyggefigurer til lyse sprites).
    * Funksjonen gjør klart BossIntro scenen ved å initiere en spiller og Boss
    * object fra prefab. NB! spiller og Boss er altså ikke UI elementer, men
    * faktiske "levende" elementer på scenen. Scenen har altså både UI og
    * rendret objecter, tilsvarende er det nødvendig med canvas som bruker
    * "Main Camera" som screenSpace. 
    * 
    * 
    * Scriptet blir for eksempel brukt i BossIntro. Kan nevnes at det er ett 
    * "ekstra" canvas i BossIntro scenen for att det sorte Image på bunnen av 
    * høyre gjørne skal overlappe Boss. (Andre canvas er ikke del av scriptet).
    * 
    * @see void PoppBokstraver(Text tekst) - henter text og popper bokstaver
    * @see IEnumerator VentLitt() - vent før popper boss sin catchPhrase
    **************************************************************************/
    private void Start()
    {
    startTime = Time.time;
          //>Sekunder det tok for spillet ble startet til første frame "loadet"

    player = Instantiate(playerPrefab, playerPos);   
    boss = Instantiate(bossPrefab, bossPos);    
                      /*
                      * Lager player og boss objecter "under" 
                      * runtime utifra prefab og med ny pos fra andre parameter
                      */

        
    bossShadow.sprite = boss.GetComponentInChildren<SpriteRenderer>().sprite;
                           //>Oppdaterer skyggefigur fra Boss prefab sin sprite

    bossName.text = boss.GetComponent<Unit>().unitName;
                                 //>Oppdaterer Text sin text til Boss sitt navn

    bossCatchPhrase.text = '"' + boss.GetComponent<Unit>().catchPhrase + '"';
//>Oppdaterer Text sin text til Boss sitt CatchPhrase plus putter " før + etter


    PoppBokstaver(bossName);      //Funksjon for å "popp" hver bokstav i texten

    bossCatchPhrase.enabled = false;       //Tar av text, vises da ikke i scene
    StartCoroutine(VentLitt()); //Funksjon for å ta på text og "popp" bokstaver

    sprite = boss.GetComponentInChildren<SpriteRenderer>();
    player.GetComponentInChildren<Playermovesin>().enabled = true;
        StartCoroutine(GoToBattleScene());
    }


    IEnumerator GoToBattleScene()
    {
        if (sceneToLoad != null)
        {
            yield return new WaitForSeconds(8f);
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);

            while (!asyncLoad.isDone)
            {
                yield return null;
            }

        }
    }

    /**********************************************************************//**
    * Funksjon som blir kalt en gang hver frame.
    *
    * Antall ganger tilkalt er dynamisk og avhenger av frameRate. 
    * Funksjonen oppdaterer medsendt sprite sin color fra 0% til 100%, dette
    * skaper samme effekt som "Fade-in".
    * 
    * @see void ReveilSprite(SpriteRenderer spriteToBeChanged) - "Fade-in"
    **************************************************************************/
    void Update()
    {
    ReveilSprite(sprite);//oppdaterer medsendt sprite sin color fra 0% til 100%
    }


    /**********************************************************************//**
    * Funksjon tar medsendt sprite og oppdaterer dens farge fra 0% til 100%
    * 
    * Funksjonen skaper "Fade-in" effekt på sprite, fra mørk skygge til lys
    * sprite på scenen. Oppdaterer "color" litt og litt hver gang tilkalt.
    **************************************************************************/
    void ReveilSprite(SpriteRenderer spriteToBeChanged)
    {
        float t = (Time.time - startTime) / duration;
        spriteToBeChanged.color = new UnityEngine.Color(1f, 1f, 1f, Mathf.SmoothStep(minimum, maximum, t));

    }

    /**********************************************************************//**
    * Funksjon for å ta på Text objectet slik vises i scene og "popp" bokstaver
    * 
    * Funksjon er IEnumerator for å ha ventetid (WaitForSeconds(2f))
    * Funksjonen tar på Text objectet Text_BossCatchPhrase
    * Funksjonen popper hver bokstav i prefab sin Unit sin CatchPhrase
    **************************************************************************/
    IEnumerator VentLitt()
    {
        yield return new WaitForSeconds(2f);                         //Ventetid
        bossCatchPhrase.enabled = true;          //Tar på Text objectet i scene
        PoppBokstaver(bossCatchPhrase);     //Popper bokstavene i Text sin text

    }



    /**********************************************************************//**
    * Funksjon for å poppe hver bokstav i medsendt Text sin text.
    **************************************************************************/
    void PoppBokstaver(Text tekst)
    {
      
        string message = tekst.text;                //Holder midlertidig texten
        tekst.text = "";                   //Nullstiller texten i Text objectet
        StartCoroutine(PoppTeksten(message, tekst));   
    //>"Popper" hver bokstav i "message" og legger hver bokstav i Text sin text

    }


    /**********************************************************************//**
    * Funksjon som "popper" hver bokstav i teksten og legger dem til Text text
    * 
    * Funksjon er IEnumerator for å ha ventetid (WaitForSeconds(2f))
    * Funksjonen popper hver bokstav i medsendt text og legger dem til en om 
    * gangen i Text sin text.
    * 
    * Funksjon brukt i Text_BossName og Text_BossCatchPhrase objectene i scene
    **************************************************************************/
    IEnumerator PoppTeksten(string tekstString, Text textComp)
    {
 
        foreach (char letter in tekstString)       //For hver bokstav i teksten
        {
            textComp.text += letter;           //Legg bokstaven i Text sin text
      
            yield return 0;                      //Litt usikker på om nødvendig
            yield return new WaitForSeconds(letterPause);            //Ventetid
        }
    }
}

