public static class StaticClass     //Statisk klasse, kan bare være ett object av denne. Brukes for å holde variabler mellom hver scene i spillet.
{
    public static string NamePlayerPrefab { get; set; }
       //>Brukes for å sende navn til Player prefab som variabel mellom scener.
    public static string NameEnemyPrefab { get; set; }
        //>Brukes for å sende navn til Enemy prefab som variabel mellom scener.

    public static string EnemyFilePath { get; set; }
    //>path til enemy filen som lagres ved oppstart og ved å trykke "save"
    
    public static string PlayerFilePath { get; set; }
    //>path til Player filen som lagres ved oppstart og ved å trykke "save"

    public static string PosPlayerFilePath { get; set; }
    //>path til Player sin posisjon filen som lagres ved å trykke "save"
    

    public static string AutoSavePathPlayer { get; set; }
    

    public static string AutoSavePathEnemy { get; set; }


}
