using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum keys
{
    LEFT = 0,
    RIGHT = 1,
    JUMP = 2
}

public class TriggerFallingRock : MonoBehaviour
{
    [SerializeField]
    private keys key;

    

    [SerializeField] private bool random;

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Activate();     
        }
    }      
    
    void Activate()
    {
        keys selected = key;

        if (random)
        {
            keys rKey = (keys)Random.Range(0, 3);
            selected = rKey;
        }

        RockFall fallingRock = GameManager.instance.rockFalls[(int)selected].gameObject.GetComponent<RockFall>();
        StartCoroutine(fallingRock.FallCor(gameObject));
    }
}
