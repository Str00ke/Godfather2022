using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public RockFall[] rockFalls;

    [Header("Panels")]
    public GameObject panelWin;
    public GameObject panelLose;

    void Awake()
    {
        instance = this;
    }
    
}
