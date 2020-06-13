using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BossIntroSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject bossPrefab;

    public Text bossName;
    public Text bossCatchPhrase;


    public Transform bossPos;
    public Transform playerPos;

    public SpriteRenderer bossShadow;

    GameObject player;
    GameObject boss;


    public float letterPause = 0.1f;


    //Reveil from shadow
    public float minimum = 0.0f;
    public float maximum = 1f;
    public float duration = 5.0f;
    private float startTime;
    SpriteRenderer sprite;
    private void Start()
    {
        startTime = Time.time;
        player = Instantiate(playerPrefab, playerPos);    //treant
        boss = Instantiate(bossPrefab, bossPos);    //james charles

        
        bossShadow.sprite = boss.GetComponentInChildren<SpriteRenderer>().sprite;

        bossName.text = boss.GetComponent<Unit>().unitName;
        bossCatchPhrase.text = '"' + boss.GetComponent<Unit>().catchPhrase + '"';

        PoppBokstaver(bossName);

        bossCatchPhrase.enabled = false;
        StartCoroutine(VentLitt());
        sprite = boss.GetComponentInChildren<SpriteRenderer>();
        player.GetComponentInChildren<Playermovesin>().enabled = true;
    }


    IEnumerator VentLitt()
    {
        yield return new WaitForSeconds(2f);
        bossCatchPhrase.enabled = true;
        PoppBokstaver(bossCatchPhrase);

    }











    void Update()
    {
        ReveilSprite(sprite);
    }

    void ReveilSprite(SpriteRenderer spriteToBeChanged)
    {
        float t = (Time.time - startTime) / duration;
        spriteToBeChanged.color = new UnityEngine.Color(1f, 1f, 1f, Mathf.SmoothStep(minimum, maximum, t));

    }



    void PoppBokstaver(Text tekst)
    {
      
        string message = tekst.text;
        tekst.text = "";
        StartCoroutine(TypeText(message, tekst));

    }

    IEnumerator TypeText(string tekstString, Text textComp)
    {
 
        foreach (char letter in tekstString)
        {
            textComp.text += letter;
      
            yield return 0;
            yield return new WaitForSeconds(letterPause);
        }
    }
}

