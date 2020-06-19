using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PosPlayerData
{

    public float x;
    public float y;
    public float z;
    public PosPlayerData(Transform posPlayer)
    {
        x = posPlayer.position.x;
        y = posPlayer.position.y;
        z = posPlayer.position.z;
    }

}
