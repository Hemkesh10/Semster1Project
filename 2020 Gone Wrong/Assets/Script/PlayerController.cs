using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRB;
    private Animator playerAnim;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public float speed = 5;
    public float turnSpeed;
    public float horizontalInput;
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * (Time.deltaTime * speed));
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        
        if (Input.GetKeyDown(KeyCode.Space)&& isOnGround)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    } 
}
