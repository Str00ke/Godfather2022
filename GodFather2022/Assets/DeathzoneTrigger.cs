using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathzoneTrigger : MonoBehaviour
{
    private Deathzone deathzoneScript;

    private void Awake()
    {
        deathzoneScript = FindObjectOfType<Deathzone>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            Debug.Log("Deathzone Triggered");
            deathzoneScript.Ison = true;
    }
}
