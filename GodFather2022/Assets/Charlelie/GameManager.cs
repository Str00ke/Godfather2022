using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public RockFall[] rockFalls;

    void Awake()
    {
        instance = this;
    }
    
}
