using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myRigidBody;

    [SerializeField]
    private InputActionReference movement;

    [SerializeField]
    private float acceleration = 10f;
    private float deceleration = 5f;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {   
            transform.localScale = new Vector2(transform.localScale.y * Mathf.Sign(myRigidBody.velocity.x), transform.localScale.y);
        }
    }

    
    //acceleration
    void move()
    {
        Vector2 inputs = movement.action.ReadValue<Vector2>();
        myRigidBody.velocity = new Vector2(inputs.x * acceleration, inputs.y * acceleration);
        
        FlipSprite();
        if(inputs.x == 0 && inputs.y == 0) {
            transform.rotation = new Quaternion(0f,0f,0f,0f);
            return;
        }
        rockCharachter();
        
    }

    private void rockCharachter()
    {

        System.Random randomNumberGen = new System.Random();
        float rand = randomNumberGen.Next() % 10;
        if(transform.localRotation.z > 0){
            transform.Rotate(Vector3.forward * -rand);
            return;
        }
        transform.Rotate(Vector3.forward * rand);

    }
}
