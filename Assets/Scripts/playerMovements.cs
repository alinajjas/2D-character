using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //for at bruge InputSystem libary

public class playerMovements : MonoBehaviour
{
    private Vector2 movement; //for at gemme det "Vector2" der kommer ind, når der bliver trykket på wsad
    private Rigidbody2D myBody; //det rigidbody som man vil flytte rundt
    private Animator myAnimator; //laver en animator variable for at kunne bruge den i koden

    [SerializeField] private int speed = 5; //bevægelseners hastighed

    // Start is called before the first frame update
    private void Awake() //kører kun en gang, når programmet starter
    {
        myBody = GetComponent<Rigidbody2D>(); //sætter mybody rigidbody til rigidbody på den gameobjekt, vi sidder på
        myAnimator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    private void OnMovement(InputValue value) //en funktion der holder øje med value af Input system
    {
        movement = value.Get<Vector2>(); //movement bliver sat til vector2 fra Input Action med WSAD

        if (movement.x != 0 || movement.y != 0) //vector bliver sat til 0,0
        {
            myAnimator.SetFloat("x", movement.x); 
            myAnimator.SetFloat("y", movement.y);

            myAnimator.SetBool("isWalking", true); //når hverken movement.x eller y er = 0, betyder det at vi walker
        }

        else 
        {
            myAnimator.SetBool("isWalking", false); //ellers walker vi ikke, så vi sætter den til false
        }
    }

    private void FixedUpdate() //mere effektiv end update
    {
        myBody.velocity = movement * speed; //sætter velocity af vores rigidbody i den hastighed, som vi har sat
    }
}
