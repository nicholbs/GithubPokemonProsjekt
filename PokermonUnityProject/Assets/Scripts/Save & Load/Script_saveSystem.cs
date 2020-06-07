using UnityEngine;
using System.IO; //Library for når vi skal jobbe med filer, Filestream objekter
using System.Runtime.Serialization.Formatters.Binary; 
                                             //>Library for binære formatterere


public static class Script_saveSystem   
{
    public static string playerPath = "/player.happyDays";    //path til player
    public static string enemyPath = "/enemy.happyDays";       //path til Enemy
    
    /**********************************************************************//**
    * Funksjon for å "save/lagre" en Unit, for eksempel spiller eller enemy.
    * 
    * Funksjonen bruker en binær formatterer for å gjøre om en serialized fil
    * til binært innhold, slik sett er det særdeles vanskelig å redigere på
    * innholdet av filen og "hacke" spillet. På andre siden er det også
    * vanskeligere for oss "spillutviklere" å gi en Unit stats og ting fra fil.
    * Funksjonen henter data fra medsendt Unit (Script_Unit player) og lagrer
    * data i ny fil som lagres på "dynamisk" sted avhengig av OperativSystem.
    * 
    * @param Script_Unit player - medsendt Unit, nemlig player som blir lagret
    * @see Script_playerData(Script_Unit player) - hente data fra Unit param
    **************************************************************************/
    public static void SavePlayer(Script_Unit player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
                         //>BinaryFormatter er et objekt som formatterer en fil

        string path = Application.persistentDataPath + playerPath;
                       //>lagrer "path" til save filen for player vi skal lagre
 //>Application.persistentDataPath gir oss et fast sted å lagre filer i runtime
    //>vanlighvis C: => Users => [user] => AppData => Localow => [company name]
  //>C:\Users\nicho\AppData\LocalLow\DefaultCompany\PokermonUnityProject\player

        FileStream stream = new FileStream(path, FileMode.Create);
        //>Lager ny FileStream objekt "stream" som reffererer til nye filen

        Script_playerData data = new Script_playerData(player);
           //>Lager ny "playerData" objekt som skal holde alle dataen vi henter
                                       //>fra Unit, i dette eksempelet "player"
        formatter.Serialize(stream, data);  //lagrer Unit (player) sin data i
            //>filen (stream) som er "Serialized" og formatterer den til binært
        stream.Close();                //Lukker filen som "stream" refferer til
    }


    /**********************************************************************//**
    * Funksjon for "Loading" av en Unit, for eksempel spiller eller enemy.
    * 
    * Funksjonen sjekker om "player" sin fil eksisterer.
    * Dersom eksisterer, gjør binært innhold til leselig og returnerer data.
    * NB! Innhold i player filen er fortsatt binært etter funksjon.
    **************************************************************************/
    public static Script_playerData LoadPlayer()
    {
        
        string path = Application.persistentDataPath + playerPath;
                       //>lagrer "path" til save filen for player vi skal loade
 //>Application.persistentDataPath gir oss et fast sted å lagre filer i runtime
    //>vanlighvis C: => Users => [user] => AppData => Localow => [company name]
  //>C:\Users\nicho\AppData\LocalLow\DefaultCompany\PokermonUnityProject\player

        if (File.Exists(path))                 //dersom path til fil eksisterer
        {
            BinaryFormatter formatter = new BinaryFormatter();
      //>Binær formatterer objektet formatter refferer til ny Binær formatterer
            FileStream stream = new FileStream(path, FileMode.Open);
             //FileStream stream objektetet reffererer til filen og "åpner" den

   Script_playerData data = formatter.Deserialize(stream) as Script_playerData;
            //>Lagrer data i filen, men siden filen er binært fra savePlayer()
            //>må vi først bruke binære formattereren sin "Deserialize" for å
            //>gjøre innholdet fra binært til lesbar tekst.
                    //>vi "caster" om, litt usikker på om "casten" henviser til
      //>[System.Serializable] i Script_playerData.cs eller "members" i klassen
                      //>class Script_playerData { public int level, health...}

            stream.Close();                                      //Lukker filen

            return data;      //returnerer dataen vi har hentet fra "saved" fil
        }
        else       //Dersom pathen ikke ble funnet, altså filen ikke eksisterer
        {
            Debug.LogError("Save file not found in " + path);   //Error melding
            return null;              //returnerer "null" og avslutter funksjon
        }
    }

    /**********************************************************************//**
    * Funksjon for å "save/lagre" en Unit, for eksempel spiller eller enemy.
    * 
    * Funksjonen bruker en binær formatterer for å gjøre om en serialized fil
    * til binært innhold, slik sett er det særdeles vanskelig å redigere på
    * innholdet av filen og "hacke" spillet. På andre siden er det også
    * vanskeligere for oss "spillutviklere" å gi en Unit stats og ting fra fil.
    * Funksjonen henter data fra medsendt Unit (Script_Unit enemy) og lagrer
    * data i ny fil som lagres på "dynamisk" sted avhengig av OperativSystem.
    * 
    * @param Script_Unit enemy - medsendt Unit, nemlig enemy som blir lagret
    * @see Script_enemyData(Script_Unit enemy) - hente data fra Unit param
    **************************************************************************/
    public static void SaveEnemy(Script_Unit enemy)
    {
        BinaryFormatter formatter = new BinaryFormatter();
                         //>BinaryFormatter er et objekt som formatterer en fil

        string path = Application.persistentDataPath + enemyPath;
                        //>lagrer "path" til save filen for enemy vi skal lagre
 //>Application.persistentDataPath gir oss et fast sted å lagre filer i runtime
    //>vanlighvis C: => Users => [user] => AppData => Localow => [company name]
   //>C:\Users\nicho\AppData\LocalLow\DefaultCompany\PokermonUnityProject\enemy

        FileStream stream = new FileStream(path, FileMode.Create);
            //>Lager ny FileStream objekt "stream" som reffererer til nye filen

        Script_enemyData data = new Script_enemyData(enemy);
            //>Lager ny "enemyData" objekt som skal holde alle dataen vi henter
                                        //>fra Unit, i dette eksempelet "enemy"
        formatter.Serialize(stream, data);     //lagrer Unit (enemy) sin data i
            //>filen (stream) som er "Serialized" og formatterer den til binært
        stream.Close();                //Lukker filen som "stream" refferer til
    }


    /**********************************************************************//**
    * Funksjon for "Loading" av en Unit, for eksempel spiller eller enemy.
    * 
    * Funksjonen sjekker om "enemy" sin fil eksisterer.
    * Dersom eksisterer, gjør binært innhold til leselig og returnerer data.
    * NB! Innhold i player filen er fortsatt binært etter funksjon.
    **************************************************************************/
    public static Script_enemyData LoadEnemy()
    {

        string path = Application.persistentDataPath + enemyPath;
                        //>lagrer "path" til save filen for enemy vi skal loade
 //>Application.persistentDataPath gir oss et fast sted å lagre filer i runtime
    //>vanlighvis C: => Users => [user] => AppData => Localow => [company name]
   //>C:\Users\nicho\AppData\LocalLow\DefaultCompany\PokermonUnityProject\enemy

        if (File.Exists(path))                 //dersom path til fil eksisterer
        {
            BinaryFormatter formatter = new BinaryFormatter();
      //>Binær formatterer objektet formatter refferer til ny Binær formatterer
            
            FileStream stream = new FileStream(path, FileMode.Open);
             //FileStream stream objektetet reffererer til filen og "åpner" den

     Script_enemyData data = formatter.Deserialize(stream) as Script_enemyData;
              //>Lagrer data i filen, men siden filen er binært fra saveEnemy()
              //>må vi først bruke binære formattereren sin "Deserialize" for å
                                //>gjøre innholdet fra binært til lesbar tekst.
                    //>vi "caster" om, litt usikker på om "casten" henviser til
      //>[System.Serializable] i Script_enemyData.cs eller "members" i klassen
                       //>class Script_enemyData { public int level, health...}

            stream.Close();                                      //Lukker filen

            return data;      //returnerer dataen vi har hentet fra "saved" fil
        }
        else       //Dersom pathen ikke ble funnet, altså filen ikke eksisterer
        {
            Debug.LogError("Save file not found in " + path);   //Error melding
            return null;              //returnerer "null" og avslutter funksjon
        }
    }
}
