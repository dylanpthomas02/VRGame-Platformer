using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Transform cam;
    public int moveSpeed = 15;
    public int jumpForce = 200;
    public LayerMask layerMask;

    float groundDistance = .1f;
    bool isGrounded = false;
    float fallMultiplier = 3f;
    float lowJumpMultiplier = 2f;
    Vector3 moveInput;
    Vector3 moveVelocity;
    Rigidbody rb;
    //Animator anim; 

    private void Awake()
    {
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
        // get camera's forward vector
        Vector3 cameraForward = cam.forward;
        // prevent up and down movement
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


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CheckGroundDistance())
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }

        //if we're falling
        //if (rb.velocity.y < 0)
        //{
        //    // fall faster than Unity's physics
        //    rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        //}
        //else if (rb.velocity.y > 0)
        //{
        //    rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        //}

        //Animating();
    }

    bool CheckGroundDistance()
    {
        return Physics.Raycast(transform.position, -transform.up, groundDistance, layerMask);
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
