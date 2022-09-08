using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathzoneTrigger : MonoBehaviour
{
    private Deathzone deathzoneScript;
    public GameObject deathzoneSpawnpoint;

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
        GameObject.FindGameObjectWithTag("Deathzone").gameObject.transform.position = deathzoneSpawnpoint.transform.position;
            deathzoneScript.Ison = true;
    }
}
