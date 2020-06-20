using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;


public class SavePlayerPos : MonoBehaviour
{
    public Transform playerPos;
    public void SavePosPlayer()
    {
        PosPlayerData posPlayer = new PosPlayerData(playerPos);
        SaveSystem.SavePosPlayer(Application.persistentDataPath + StaticClass.PosPlayerFilePath, posPlayer);

        //Debug.Log(playerPos.position.x.ToString());
    }

    public void LoadPosPlayer()
    {
        PosPlayerData temp = SaveSystem.LoadPlayerPos(Application.persistentDataPath + StaticClass.PosPlayerFilePath);
        Vector3 posVector = new Vector3(temp.x, temp.y, temp.z);
        playerPos.position = posVector;
        //this.GetComponent<Transform>().position.y = temp.position.y;
        //this.GetComponent<Transform>().position.z = temp.position.z;
        //Debug.Log(playerPos.position.x.ToString());
    }

}
