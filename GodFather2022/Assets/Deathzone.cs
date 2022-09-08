using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathzone : MonoBehaviour
{
    [Header("Deatzone Parameters")]
    public bool Ison;
    public int[] deathzoneSpeed;
    public int index;

    PlayerControls controlsScript;

    private void Awake()
    {
        controlsScript = FindObjectOfType<PlayerControls>();
    }

    void Start()
    {
        Ison = false;
        index = deathzoneSpeed[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Ison)
        {
            Vector2 moving = Vector2.right;
            transform.Translate(moving * deathzoneSpeed[index] /75);
        } else
        {
            Vector2 notMoving = new Vector2(0, 0);
            transform.Translate(notMoving);
        }
    }

    public void ChangeInt()
    {
        Ison = false;
        index++;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            controlsScript.Death();
    }

}
