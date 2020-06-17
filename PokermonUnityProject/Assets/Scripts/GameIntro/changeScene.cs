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
        StartCoroutine(ChangeTheScene(sceneToChangeTo));
    }
    
    public IEnumerator ChangeTheScene(string sceneChangeTo)
    {
        StaticClass.NamePlayerPrefab = "Player_Prefabs\\" + hvilkenPlayer;
        StaticClass.NameEnemyPrefab = "Boss_Prefabs\\" + hvilkenBoss;


        StaticClass.EnemyFilePath = "\\" + hvilkenBoss;
        StaticClass.PlayerFilePath = "\\" + hvilkenPlayer;

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneChangeTo);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
