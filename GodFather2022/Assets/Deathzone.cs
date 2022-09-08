using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathzone : MonoBehaviour
{
    [Header("Deatzone Parameters")]
    public bool Ison;
    public float[] deathzoneSpeed;
    public int index = 0;

    PlayerControls controlsScript;

    private void Awake()
    {
        controlsScript = FindObjectOfType<PlayerControls>();
    }

    void Start()
    {
        Ison = false;
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
            transform.Translate(moving * deathzoneSpeed[index] /50);
        } else
        {
            Vector2 notMoving = new Vector2(0, 0);
            transform.Translate(notMoving);
        }
    }

    private void ChangeInt()
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
