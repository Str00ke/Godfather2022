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

    public bool isGrounded = false;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

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
        } else
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 1, LayerMask.GetMask("Plateform"));
            if (hit.collider == null && isGrounded) isGrounded = false;
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


}
