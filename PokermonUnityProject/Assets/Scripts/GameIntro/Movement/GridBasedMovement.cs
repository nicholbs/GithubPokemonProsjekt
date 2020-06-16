using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBasedMovement : MonoBehaviour
{
    public float moveSpeed = 1f;         //Movementspeed til objectet festet på
    public Transform movePoint;           
     //>prefab sin childComponent movepoint som er punktet det skal beveges til

    public LayerMask whatStopsMovement;
                               //>Velg hvilket layer spiller skal collidere med

    //public Animator animasjon;                                               //Avkommenter og implementer for å ha animasjon under bevegelse


    /**********************************************************************//**
    * Funksjon som blir kalt før første frame oppdateringen, altså med en gang.
    * 
    * For at prefab sin childComponent skal kunne ha egen transform må den bli
    * gjort om til eget object og ikke som child til prefab.
    * Ved å sette objectet.parent = null blir componenten til eget object!
    **************************************************************************/
    void Start()
    {
        movePoint.parent = null;    
         //>Child componenten til prefab blir satt til å ikke være child lenger
    }


    /**********************************************************************//**
    * Funksjon som blir kalt 50 ish ganger hver frame.
    *
    * Antall ganger tilkalt er dynamisk og avhenger av frameRate. Er derfor
    * ypperlig for å hente inn input fra brukeren.
    * Funksjonen oppdaterer spilleren sin posisjon 50 ish ganger hver frame
    * til prefab sin movePoint er. (under runtime blir prefab sin movePoint
    * omgjort til å ikke være barnet til prefab, dette er slik movePoint ikke
    * "arver" posisjonen til prefab)
    * det er fire if statements:
    * to første er for å sjekke om input fra brukeren har som hensikt å endre
    * på spilleren sin horizontale posisjon.
    * To siste er for å sjekke om input fra brukeren har som hensikt å endre på
    * spilleren sin verticale posisjon.
    * 
    * Under input sjekkene blir det sett etter om det er hindringer i veien for
    * spilleren, en sjekk på om han i det hele tatt skal få lov til å bevege
    * seg.
    * Er fryktelig mange if statements, kanskje en rework er nødvendig.
    **************************************************************************/
    void Update()
    {
           /*
            * Setter festet object sin posijon til å være lik den nye Vectoren
            * Nye vectoren er laget med parameterene:
            * nåværende pos, target pos (hvor skal til) og noe med hastiget osv
            * Time.deltaTime gjør bevegelse likt for alle maskiner.
            */
    transform.position = Vector3.MoveTowards(transform.position, 
                               movePoint.position, moveSpeed * Time.deltaTime);


           /*
            * Dersom distansen mellom gamle pos og nye pos er mindre enn 0.05f
            * Dersom spiller står stille(nåværende pos er basically lik ny pos)
            */
if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
{
    /*
     * Dersom input verdien for Horizontal, nemlig (w/s) eller(piltast opp/ned)
     * fra brukeren er lik absolutte verdien 1, absolutt er avstand fra 0
     * Har altså ikke noe å si om input er w=1 s=-1 pilOpp=1 pillNed=-1
     * Med andre ord, sjekker om input fra bruker har med Horizontal å gjøre!
     */
    if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
    {       
        /*
         * Dersom det ikke er objecter i veien for spiller, altså sjekker om
         * det er ett "collider2d" object hvor spiller skal bevege seg.
         * Posisjon hvor spiller skal bevege seg blir satt i ny Vector3 ut fra
         * Horizontale input og nåværende plassering på spiller.
         * 
         * Dersom det ikke var ett hinder, settes den Horizontal inputen 
         * inn i ny vector og "movePoint" får oppdatert pos.
         * NB! Update() oppdaterer kontinuerlig spiller pos lik til movePoint
         */
        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(
              Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, whatStopsMovement)) 
        {
            movePoint.position += new Vector3(
                                       Input.GetAxisRaw("Horizontal"), 0f, 0f);
        }

    }


    /*
     * Dersom input verdien for Vertical, nemlig (d/a) eller 
     * (piltast venstre/høyre) fra brukeren er lik absolutte verdien 1
     * NB! absolutt verdi er avstand fra 0.
     * 
     * Har altså ikke noe å si om input er d=1 a=-1 pilHøyre=1 pillVenstre=-1
     * Med andre ord, sjekker om input fra bruker har med Vertical å gjøre!
     * 
     * NB! Ettersom sjekken på hvilken input er gitt fra bruker, altså om han
     * vil flytte seg Verticalt kommer etter Horizontalt vil alle Diagonale
     * input bli tolket som Horizontale inputs.
     */
    else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)       
    {


    /*
     * Dersom det ikke er objecter i veien for spiller, altså sjekker om
     * det er ett "collider2d" object hvor spiller skal bevege seg.
     * Posisjon hvor spiller skal bevege seg blir satt i ny Vector3 ut fra
     * Verticale input og nåværende plassering på spiller.
     * 
     * Dersom det ikke var ett hinder, settes den Verticale inputen 
     * inn i ny vector og "movePoint" får oppdatert pos.
     * NB! Update() oppdaterer kontinuerlig spiller pos lik til movePoint
     */
        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, 
                    Input.GetAxisRaw("Vertical"), 0f), .2f, whatStopsMovement))
        {
            movePoint.position += new Vector3(0f, 
                                             Input.GetAxisRaw("Vertical"), 0f);

        }

    }
            //animasjon.SetBool("moving", false);                              //Avkommenter og implementer for å ha animasjon under bevegelse                                       

        }

        //else                                                                 //Avkommenter og implementer for å ha animasjon under bevegelse
        //{
        //    animasjon.SetBool("moving", true);
        //}



    }

}