using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossurprefab : MonoBehaviour
{
    public Sprite Introsprite;


    // Start is called before the first frame update
    void Start()
    {
        //Sets this object's tag to "interObject", found in tag-hierarchy
        gameObject.tag = "interObject";
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
