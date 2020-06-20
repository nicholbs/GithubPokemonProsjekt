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
        StaticClass.NamePlayerPrefab = "Player_Prefabs\\" + hvilkenPlayer;//valgt spiller prefab sin path
        StaticClass.NameEnemyPrefab = "Boss_Prefabs\\" + hvilkenBoss;//valgt boss prefab sin path


        StaticClass.EnemyFilePath = "\\" + hvilkenBoss;     //lagring av spiller path
        StaticClass.PlayerFilePath = "\\" + hvilkenPlayer;      //lagring av boss path

        StaticClass.PosPlayerFilePath = "\\" + hvilkenPlayer + "_Pos";      //for pos openworld


        
        StaticClass.AutoSavePathPlayer = "\\" + hvilkenPlayer + "_AutoSave";    //path til siste autosave
        StaticClass.AutoSavePathEnemy = "\\" + hvilkenBoss + "_AutoSave";    //path til siste autosave

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneChangeTo);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
