using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{

    /**********************************************************************//**
    * Funksjon som forandrer "Scene" i Unity.
    *
    * Funksjonen tar string av navnet på scene det skal byttes til.
    * @param string sceneToChangeTo - navn på scene som skal byttes til
    **************************************************************************/
    public void changeToScene(string sceneToChangeTo)
    {
        SceneManager.LoadScene(sceneToChangeTo);
        
    }
}
