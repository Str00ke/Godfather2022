using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("Player Componnents")]
    public Rigidbody2D playerRb;

    [Header("Movements Values")]
    public float speed;
    public float jumpIntensity;
    public float gravityScale;


    [Header("GroundCheck Parameters")]
    public Transform groundCheck;
    public float groundCheckRadius;
    public bool isGrounded = false;
    public LayerMask myLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Movements

        Vector2 movements = new Vector2(Input.GetAxisRaw("Horizontal"), playerRb.velocity.y);
        transform.Translate(movements * speed * Time.deltaTime);

        //Jump

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log(" Z Pressed");
            if (isGrounded)
            {
            isGrounded = false;
            Vector2 jump = new Vector2(playerRb.velocity.x, 1 * jumpIntensity);
                playerRb.velocity = jump;
            }
        }

            //Gravity
            if (!isGrounded)
            {
                Vector2 fall = new Vector2(playerRb.velocity.x, playerRb.velocity.y - gravityScale);
                playerRb.velocity = fall;
            }
    }


    private void FixedUpdate()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            Debug.Log("Collision with platform");
            isGrounded = true;
        }
    }


    // Draw a Gizmo of the GroundCheck
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

}
