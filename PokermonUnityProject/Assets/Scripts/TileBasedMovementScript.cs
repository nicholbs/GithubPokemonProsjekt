using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBasedMovementScript : MonoBehaviour
{
    public float movementSpeed = 5f;

    public Animator animator;
    public Rigidbody2D rb;

    Vector2 movement;
    /***********niga*********************************************************//**
    * Funksjon som blir kalt en gang hver frame.
    *
    * Antall ganger tilkalt er dynamisk og avhenger av frameRate. Er derfor
    * ypperlig for å hente inn input fra brukeren.
    **************************************************************************/
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
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
        //                         mengden med tid siden funksjon ble kalt sist

    }
}
