using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class BossIntroSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerStation;
    public Transform enemyStation;

    public Text enemyName;
    public Text enemyCatchPhrase;

    Unit playerUnit;
    Unit enemyUnit;

    public GameObject sizeRefference;

    public BossBattleHud enemyHUD;

    Vector3 gammelPosPlayer;
    Vector3 gammelPosEnemy;


    void Start()
    {
        //gammelPosPlayer = playerPrefab.GetComponent<Transform>().position;
        //gammelPosEnemy = enemyPrefab.GetComponent<Transform>().position;

        StartCoroutine(SetupBossIntro());
    }

    IEnumerator SetupBossIntro()
    {
        playerPrefab.GetComponent<Transform>().position = new Vector3(0, 0, 0);
        enemyPrefab.GetComponent<Transform>().position = new Vector3(0, 0, 0);

        //playerPrefab.GetComponent<Transform>().position = playerStation.position;
        //enemyPrefab.GetComponent<Transform>().position = enemyStation.position;

        GameObject playerGO = Instantiate(playerPrefab, playerStation);
        playerUnit = playerGO.GetComponent<Unit>();


        GameObject enemyGO = Instantiate(enemyPrefab, enemyStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        Vector3 sizeCalculated = sizeRefference.GetComponent<Renderer>().bounds.size;

        enemyUnit.GetComponent<Transform>().localScale = sizeCalculated;
        playerUnit.GetComponent<Transform>().localScale = sizeCalculated;

        enemyHUD.SetHud(enemyUnit);

        yield return new WaitForSeconds(4f);

        playerPrefab.GetComponent<Transform>().position = gammelPosPlayer;
        enemyPrefab.GetComponent<Transform>().position = gammelPosEnemy;

    }
}
