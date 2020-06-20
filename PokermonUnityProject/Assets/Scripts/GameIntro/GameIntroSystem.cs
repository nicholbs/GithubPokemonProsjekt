using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class GameIntroSystem : MonoBehaviour
{
    public GameObject player;
    public GameObject boss;


    // Start is called before the first frame update
    void Start()
    {


        string playerPath = Application.persistentDataPath + StaticClass.PlayerFilePath;
        string enemyPath = Application.persistentDataPath + StaticClass.EnemyFilePath;

        if (File.Exists(Application.persistentDataPath + StaticClass.AutoSavePathPlayer))
        {
            player.GetComponent<Unit>().LoadPlayerAuto();
            Debug.Log("Player auto filen fantes");
        }
        
        else if (File.Exists(playerPath))        //Hvis det finnes en save File?
        {
            Debug.Log("Player filen fantes");
            player.GetComponent<Unit>().LoadPlayer();
        
        }
        else if (!File.Exists(playerPath))
        {
            Debug.Log("Player filen fantes ikke");
            player.GetComponent<Unit>().SavePlayer();
           
        }


        
        if (File.Exists(Application.persistentDataPath + StaticClass.AutoSavePathEnemy))
        {
            boss.GetComponent<Unit>().LoadEnemyAuto();
            Debug.Log("Enemy auto filen fantes");
        }
        else if (File.Exists(enemyPath))        //Hvis det finnes en save File?
        {
            Debug.Log("Enemy filen fantes");
            boss.GetComponent<Unit>().LoadEnemy();

        }
        else if (!File.Exists(enemyPath))
        {
            Debug.Log("Enemy filen fantes ikke");
            boss.GetComponent<Unit>().SaveEnemy();

        }


    }

}
