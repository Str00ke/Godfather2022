using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{

    private void Awake()
    {
        
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
            DisplayWin();
    }

    private void DisplayWin()
    {
        Debug.Log("LEVEL CLEARED");
        GameManager.instance.panelWin.SetActive(true);
        Time.timeScale = 0;
    }

}
