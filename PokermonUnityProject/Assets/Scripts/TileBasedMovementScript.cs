using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBasedMovementScript : MonoBehaviour
{
    public float movementSpeed = 5f;          //statisk movementSpeed på Objekt

    public Animator animator;  //variabel for animator, bruk animator som param
    public Rigidbody2D rb; 
                        //>variabel for RigidBody2D, bruk RigidBody2D som param

    Vector2 movement;
    /**********************************************************************//**
    * Funksjon som blir kalt en gang hver frame.
    *
    * Antall ganger tilkalt er dynamisk og avhenger av frameRate. Er derfor
    * ypperlig for å hente inn input fra brukeren.
    **************************************************************************/
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");       //Hent ny x posisjon
        movement.y = Input.GetAxisRaw("Vertical");         //Hent ny y posisjon

        animator.SetFloat("Horizontal", movement.x);
                       //>set param "Horizontal" for animator lik ny x posisjon
        animator.SetFloat("Vertical", movement.y);
                         //>set param "Vertical" for animator lik ny y posisjon
        animator.SetFloat("Speed", movement.sqrMagnitude);
             //>set param "Speed" for animator lik square root av ny pos vector
    }


    /**********************************************************************//**
    * Funksjon som blir kalt 50 ish ganger i sekundet.
    *
    * Antall ganger tilkalt er statisk, 50 ish ganger i sekundet. Er derfor
    * ypperlig for å oppdatere objekter, for eksempel med deres movement.
    **************************************************************************/
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movementSpeed * 
                                                          Time.fixedDeltaTime);
        //beveg rigidBody fra nåværende pos + ny pos * bevegelseshastighet *
                                //>mengden med tid siden funksjon ble kalt sist

    }
}
