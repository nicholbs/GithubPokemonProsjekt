using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionObject : MonoBehaviour
{
    public string sceneToLoad = null;
    //>skriv navn på scene objectet skiftet til dersom det bli "Interacted" med

    /**********************************************************************//**
    * Funksjon for å gjøre object "interactable".
    * 
    * Scriptet i helhet har som funksjon å gjøre object til "interactable".
    * Scriptet blir lagt til på object slik at spilleren kan ha knapp på
    * Input manager, f eks 'e' til å sette i gang funksjonen "DoInteraction" på
    * Objecter dersom spiller er innenfor objectet sin collision sone.  
    * Funksjon har ventetid og er derfor Coroutine.
    * 
    * Funksjonen gjør per nå at objecter skifter zone til gitt som parameter.
    **************************************************************************/
    IEnumerator DoInteraction()
    {  

        if (sceneToLoad != null)          //Sjekker om det er gitt et parameter
        { 
           /*
            * Kunne brukt LoadScene, men AsyncOperation er anbefalt for å unngå
            * "freeze frame" imens scenen skal loades.
            */
          
           AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);

            while (!asyncLoad.isDone)   
                   //>imens scenen ikke er loaded, kan være denne er unødvendig
            {
                yield return null;      //tror denne venter null sek, basically
            }
        }
    }
}
