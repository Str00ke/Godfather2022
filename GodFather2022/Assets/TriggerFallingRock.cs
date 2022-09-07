using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFallingRock : MonoBehaviour
{
    [SerializeField]
    private BlockInput blockInput;

    [SerializeField]
    private RockFall[] rockFalls;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < rockFalls.Length; i++)
        {
            RockFall fallingRock = rockFalls[i].gameObject.GetComponent<RockFall>();
            StartCoroutine(fallingRock.FallCor());
        }
    }        
}
