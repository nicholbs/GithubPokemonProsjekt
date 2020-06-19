using UnityEngine;
using System.IO; //Library for når vi skal jobbe med filer, Filestream objekter
using System.Runtime.Serialization.Formatters.Binary;
using System;
//>Library for binære formatterere


public static class SaveSystem   
{
    //public static string playerPath = StaticClass.PlayerFilePath + ".happyDays";    //path til player
    //public static string enemyPath = StaticClass.EnemyFilePath + ".happyDays";       //path til Enemy


    /**********************************************************************//**
    * Funksjon for å Save en Unit, nemlig player. Brukt i "Save" knapper
    *
    * @see Script_saveSystem.SavePlayer(Script_Unit) - Unit (player) som lagres
    **************************************************************************/
    public static void SaveUnitPlayerData(string filePath, PlayerData objectToWrite, bool append = false)
    {
        using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
        {
            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            binaryFormatter.Serialize(stream, objectToWrite);
        }
    
    }

    /**********************************************************************//**
    * Funksjon for å "Loading" av Unit, nemlig player. Brukt i "Load" knapper
    *
    * @see Script_saveSystem.LoadPlayer() - Unit (player) som lagres
    **************************************************************************/
    public static PlayerData ReadFromBinaryFile(string filePath)
    {

        using (Stream stream = File.Open(filePath, FileMode.Open))
        {
            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            return (PlayerData) binaryFormatter.Deserialize(stream);
        }
    }




    /**********************************************************************//**
    * Funksjon for å Save en Unit, nemlig player. Brukt i "Save" knapper
    *
    * @see Script_saveSystem.SavePlayer(Script_Unit) - Unit (player) som lagres
    **************************************************************************/
    public static void SavePosPlayer(string filePath, PosPlayerData objectToWrite, bool append = false)
    {
        using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
        {
            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            binaryFormatter.Serialize(stream, objectToWrite);
        }

    }

    /**********************************************************************//**
    * Funksjon for å "Loading" av Unit, nemlig player. Brukt i "Load" knapper
    *
    * @see Script_saveSystem.LoadPlayer() - Unit (player) som lagres
    **************************************************************************/
    public static PosPlayerData LoadPlayerPos(string filePath)
    {

        using (Stream stream = File.Open(filePath, FileMode.Open))
        {
            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            return (PosPlayerData)binaryFormatter.Deserialize(stream);
        }
    }






}
