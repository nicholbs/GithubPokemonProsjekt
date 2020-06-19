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


    //public Transform playerPos;
    // Start is called before the first frame update
    void Start()
    {
        //GameObject playerPrefab = Resources.Load<GameObject>(
        //                                             StaticClass.NamePlayerPrefab);

        string playerPath = Application.persistentDataPath + StaticClass.PlayerFilePath;
        string enemyPath = Application.persistentDataPath + StaticClass.EnemyFilePath;

        if (File.Exists(playerPath))        //Hvis det finnes en save File?
        {
            Debug.Log("Player filen fantes");
            player.GetComponent<Unit>().LoadPlayer();
        
        }
        else if (!File.Exists(playerPath))
        {
            Debug.Log("Player filen fantes ikke");
            player.GetComponent<Unit>().SavePlayer();
           
        }

        if (File.Exists(enemyPath))        //Hvis det finnes en save File?
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


  

    // /**********************************************************************//**
    //* Funksjon for å "Loading" av Unit, nemlig player. Brukt i "Load" knapper
    //*
    //* @see Script_saveSystem.LoadPlayer() - Unit (player) som lagres
    //**************************************************************************/
    // public void LoadPlayerAtBeginning(GameObject Player_Pos)
    // {
    //     GameObject playerPrefab = Resources.Load<GameObject>(
    //                                              StaticClass.NamePlayerPrefab);


    //     PlayerData data = SaveSystem.LoadPlayer();
    //     player.GetComponent<Unit>().unitName = data.unitName;
    //     player.GetComponent<Unit>().catchPhrase = data.unitCatchPhrase;

    //     player.GetComponent<Unit>().unitLevel = data.level;
    //     player.GetComponent<Unit>().damage = data.level;

    //     player.GetComponent<Unit>().currentHP = data.currentHP;
    //     player.GetComponent<Unit>().maxHP = data.maxHealth;

    //     player.GetComponent<Unit>().healingAmount = data.unitHealing;

    //     player.GetComponent<Unit>().currentEXP = data.currentXP;
    //     player.GetComponent<Unit>().maxEXP = data.maxXP;
    //     player.GetComponent<Unit>().xpToGiveIfDefeated = data.xpGivenIfDeafeted;


    //     Vector3 position;
    //     position.x = data.position[0];
    //     position.y = data.position[1];
    //     position.z = data.position[2];


    //     player.GetComponent<Transform>().position = position;
    //     Player_Pos.GetComponent<Transform>().position = position;

    //     transform.position = position;

    //     player.GetComponent<SpriteRenderer>().sprite =
    //                         playerPrefab.GetComponent<SpriteRenderer>().sprite;

    //     /*
    //      * Oppdaterer valgt player prefab nedenfor
    //      */



    //     playerPrefab.GetComponent<Unit>().unitName = data.unitName;
    //     playerPrefab.GetComponent<Unit>().catchPhrase = data.unitCatchPhrase;

    //     playerPrefab.GetComponent<Unit>().unitLevel = data.level;
    //     playerPrefab.GetComponent<Unit>().damage = data.damage;

    //     playerPrefab.GetComponent<Unit>().maxHP = data.maxHealth;
    //     playerPrefab.GetComponent<Unit>().currentHP = data.currentHP;

    //     playerPrefab.GetComponent<Unit>().healingAmount = data.unitHealing;

    //     playerPrefab.GetComponent<Unit>().currentEXP = data.currentXP;
    //     playerPrefab.GetComponent<Unit>().maxEXP = data.maxXP;
    //     playerPrefab.GetComponent<Unit>().xpToGiveIfDefeated =
    //                                                     data.xpGivenIfDeafeted;


    //     playerPrefab.GetComponent<Transform>().position = position;
    //     playerPrefab.GetComponent<Transform>().Find(
    //                                          "Player_Pos").position = position;

    // }
}
