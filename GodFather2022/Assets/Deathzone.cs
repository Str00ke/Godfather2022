using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathzone : MonoBehaviour
{
    [Header("Deatzone Parameters")]
    public bool isOn;
    public int[] deathzoneSpeed;
    public int index;

    PlayerControls controlsScript;

    private void Awake()
    {
        controlsScript = FindObjectOfType<PlayerControls>();
    }

    void Start()
    {
        isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (isOn)
        {
            Vector2 moving = Vector2.right;
            transform.Translate(moving * deathzoneSpeed[index] * Time.deltaTime);
        } else
        {
            Vector2 notMoving = new Vector2(0, 0);
            transform.Translate(notMoving);
        }
    }

    public void ChangeInt()
    {
        isOn = false;
        index++;
        print($"The index is now {index}");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            controlsScript.Death();
    }

}
