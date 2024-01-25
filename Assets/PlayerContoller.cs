using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] private float speed = 12f;
    private Vector3 velocity;
    private bool GroundedPlayer;
    private float jumpHeight = 1.0f; 
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PlayerMove()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * y;
        if (GroundedPlayer)
        {
            characterController.Move(move * speed * Time.deltaTime);
            if (velocity.y < 0) velocity.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                velocity.y += MathF.Sqrt(jumpHeight * -3.0f * -9.81f);
            }
        }
        velocity.y += 9.81f * Time.deltaTime;
        CharacterController.Move(velocity + Time.deltaTime);
    }
}
