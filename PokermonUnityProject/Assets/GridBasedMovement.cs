using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBasedMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public Transform movePoint;

    public LayerMask whatStopsMovement;

    //public Animator animasjon;


    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;    //Child componenten til prefab blir ikke child i scenen under runtime
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);   //Time.deltaTime gjør bevegelse likt for alle systemer, datamaskiner.

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {

            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, whatStopsMovement)) //Hvis det ikke er objecter foran oss så kan vi bevege oss.
                                                                                                                                                //OverlapCircle lager en "imaginative" sirkel rundt et sted i rommet (det du angir som parametere) og lar oss sjekke om det er noen "colliders" der.
                                                                                                                                                //andre parameter i OverlapCircle er hvor stor sirkel vi vil "tegne", den trenger ikke være stor, men stor nokk til å "interacte" med. Siste param er "layer" som sjekkes for colliders (tror jeg)
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);

                }
            } else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)       //På grunn av prioriteten, altså at du alltid sjekker Horizontal input før vertical vil funksjonen alltid "tolke" en diagonal input som en bevegelse på den horisontale aksen
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);

                }
            }
            //animasjon.SetBool("moving", false);

        } 
        
        //else
        //{
        //    animasjon.SetBool("moving", true);
        //}



    }
}
