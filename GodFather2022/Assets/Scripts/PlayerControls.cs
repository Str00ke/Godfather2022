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

    public Vector3 baseVec = Vector3.one;

    [SerializeField] float groundTestVal;
    [SerializeField] LayerMask plateformLayer;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        baseVec = Vector3.one;
    }

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("BgMusic");   
    }

    // Update is called once per frame
    void Update()
    {
        // Movements

        Vector2 movements = new Vector2(Input.GetAxisRaw("Horizontal"), playerRb.velocity.y);

        if (movements.x < 0 && baseVec.x == 0) movements.x = 0;
        if (movements.x > 0 && baseVec.y == 0) movements.x = 0;

        transform.Translate(movements * speed * Time.deltaTime);

        //Jump

        if (Input.GetKeyDown(KeyCode.Z) && baseVec.z > 0)
        {
            
            if (isGrounded)
            {
                FindObjectOfType<AudioManager>().Play("Jump");
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

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, groundTestVal, plateformLayer);
        if (hit.collider == null && isGrounded) isGrounded = false;
    }


    private void FixedUpdate()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)(-Vector2.up * transform.localScale.y * groundTestVal));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            isGrounded = true;
            FindObjectOfType<AudioManager>().Play("PlayerTouchGround");
        }
    }


}
