using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;



public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;   //Variabel for om game er paused
    public GameObject pauseMenuUI;          //GameObject for å putte panel inni
    public GameObject player;         //GameObject som reffererer til spilleren

    /**********************************************************************//**
    * Funksjon som blir kalt en gang og før alle andre frames.
    *
    * Antall ganger tilkalt er statisk og en gang.
    * Funksjonen setter panelet "pause meny-en" til å være inaktivt.
    * Tror ikke denne er nødvendig per def nå ettersom panelet er inaktivt ved
    * oppstart? Må dobbeltsjekkes.
    **************************************************************************/
    void Start()
    {
        pauseMenuUI.SetActive(false);//Setter pause panelet til å være inaktivt
    }

    /**********************************************************************//**
    * Funksjon som blir kalt en gang hver frame.
    *
    * Antall ganger tilkalt er dynamisk og avhenger av frameRate. Er derfor
    * ypperlig for å hente inn input fra brukeren.
    **************************************************************************/
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //Dersom spiller trykker 'escape'
        {
            if (GameIsPaused)    //Dersom pause meny allerede vises når spiller
                                                           //>trykker escape...
            {
                Resume();              //Tar vekk panelet og forstetter spillet
            }
            else//Dersom pause meny ikke er tilstede når spiller trykker escape
            {
                Pause();                                     //vis "pause menu"
            }

        }
    }
 
    /**********************************************************************//**
    * Funksjon for å ta vekk pause menyen og lar spilleren bevege seg.
    *
    * Funksjonen setter pause menyen til å være inaktiv.
    * Setter GameIsPaused variabelen som false.
    * GameObject player, hvor vi har refferert til spilleren sin bevegelse
    * script "TileBasedMovement" blir enabled og lar spilleren bevege seg.
    * Annen løsning er å sette "tiden" i spillet til normal, nemlig 1f. 
    * Kontra 0f som er stille.
    **************************************************************************/
    public void Resume()
    {      
        pauseMenuUI.SetActive(false);  //setter pause menyen til å være inaktiv
        GameIsPaused = false;        //Setter GameIsPaused variabelen som false
        player.GetComponent<TileBasedMovement>().enabled = true;
        //>Gjør bevegelses scriptet til spilleren aktiv og spiller kan bevege seg
        //Time.timeScale = 1f;            //Denne setter tiden til å bli "normal"
  
    }      

    
    /**********************************************************************//**
    * Funksjon for å vise pause menyen, og setter player sin movement inaktiv.
    *
    * Funksjonen setter pause menyen til å være aktiv.
    * GameObject player, hvor vi har refferert til spilleren sin bevegelse
    * script "TileBasedMovement" blir disabled og spiller kan ikke bevege seg.
    * GameIsPaused blir satt til "true".
    * Annen løsning er å sette tiden i spillet "Time.timescale" til 0f, men da
    * har du effektivt satt tiden i spillet til å være stille.
    **************************************************************************/
    void Pause()
    {
        pauseMenuUI.SetActive(true);                //pause panelet kommer frem
        player.GetComponent<TileBasedMovement>().enabled = false;
   //>Gjør bevegelses scriptet til spilleren inaktiv og spiller kan ikke bevege
        GameIsPaused = true;          //Setter GameIsPaused variabelen som true


        //Time.timeScale = 0f;          //Setter tiden til å bli stillestående
    }

    /**********************************************************************//**
    * Funksjon for å skifte scene, f eks til hovedMeny-en.
    * 
    * Funksjon for skifter scene til medsendt parameter scene.
    * Lager log i Debug "loading menu.."
    * Dersom vi velger å kødde med tiden i spillet kan det være greit å
    * "normalisere" tiden med f eks Time.timeScale = 1f. 
    * 
    * @param Object sceneToLoad - scenen som skal bli skiftet til
    **************************************************************************/
    public void LoadMeny(Object sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad.name);             //Loader ny scene
        Debug.Log("Loading menu...");                            //Ny Debug log
      
      //Time.timeScale = 1f;            //Denne setter tiden til å bli "normal"
    }


    /**********************************************************************//**
    * Funksjon for å avslutte executable versjon av spillet.
    * 
    * Funksjonen fungerer ikke i Unity editor, men når spillet kjøres som
    * executable vil funksjonen avslutte økten. Effektivt avsluttes spillet.
    **************************************************************************/
    public void QuitGame()
    {
        Debug.Log("Quitting game...");                           //Ny Debug log
        Application.Quit();                  //Spillet som executable avsluttes
    }
}
