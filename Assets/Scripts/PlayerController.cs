using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
   private Rigidbody rb; // rigidbody of the player
   private float movementX;  // movement along X and Y axes.
   private float movementY;
   private int count; // count of pickups collected
   public float speed = 0;  // player speed

   void Start()
   {
      rb = GetComponent<Rigidbody>(); // attach rb to player
      count = 0; 
   }

   void OnMove(InputValue movementValue) // called on movement input
   {
      Vector2 movementVector = movementValue.Get<Vector2>(); // convert movement input to vector2
      movementX = movementVector.x;
      movementY = movementVector.y;
   }

   private void FixedUpdate() // called once per frame
   {
      Vector3 movement = new Vector3(movementX, 0.0f, movementY);
      rb.AddForce(movement * speed); // apply force to player rb
   }
    
   private void OnTriggerEnter(Collider other) // called upon collision
   {
      if (other.gameObject.CompareTag("Pickup"))
      {
         other.gameObject.SetActive(false); // deactivate the collided object
         count = count + 1;
      }
   }
}