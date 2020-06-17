using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string hvilkenPlayer = null;
    public string hvilkenBoss = null;
    /**********************************************************************//**
    * Funksjon som forandrer "Scene" i Unity.
    *
    * Funksjonen tar string av navnet på scene det skal byttes til.
    * @param string sceneToChangeTo - navn på scene som skal byttes til
    **************************************************************************/
    public void ChangeToScene(string sceneToChangeTo)
    {
        StaticClass.NamePlayerPrefab = "Player_Prefabs\\" + hvilkenPlayer;
        StaticClass.NameEnemyPrefab = "Boss_Prefabs\\" + hvilkenBoss;

        SceneManager.LoadScene(sceneToChangeTo);
        
    }
}
