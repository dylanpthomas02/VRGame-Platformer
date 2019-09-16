using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Transform cam;

    public int moveSpeed = 15;
    //Vector3 mainCamera; // start mainCamera = Camera.main;
    Vector3 moveInput;
    Vector3 moveVelocity;
    Rigidbody rb; // start getcomponent. Freeze rotation on all axes in inspector!
    //Animator anim; 

    private void Start()
    {
        //mainCamera = Camera.main.transform.forward;
        rb = GetComponent<Rigidbody>();
        //anim = GetComponent<Animator>();
    }

    void Update()
    {
        // get input
        float lh = Input.GetAxis("Horizontal");
        float lv = Input.GetAxis("Vertical");

        // vector that holds input values
        moveInput = new Vector3(lh, 0f, lv);
        // get camera forward vector
        //Vector3 cameraForward = mainCamera;
        Vector3 cameraForward = cam.forward;
        // make sure we prevent moving up and down
        cameraForward.y = 0;


        // account for camera
        Quaternion cameraRelativeRotation = Quaternion.FromToRotation(Vector3.forward, cameraForward);
        // actually rotate camera
        Vector3 lookToward = cameraRelativeRotation * moveInput;

        if (moveInput.sqrMagnitude > 0)
        {
            // create Ray originating from player and coming towards camera
            Ray lookRay = new Ray(transform.position, lookToward);
            // rotate player
            //transform.LookAt(lookRay.GetPoints(1));
            transform.LookAt(lookRay.GetPoint(1));
        }

        // direction * speed * inputValue
        // doesn’t actually move character. += would move character.
        moveVelocity = transform.forward * moveSpeed * moveInput.sqrMagnitude;

        //Animating();
    }

    void FixedUpdate()
    {
        // moves character
        rb.velocity = moveVelocity;
    }

    void Animating()
    {
        //
        //anim.SetFloat("blendSpeed", rb.velocity.magnitude);
    }

}
