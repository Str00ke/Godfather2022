using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public RockFall[] rockFalls;

    [Header("Panels")]
    public GameObject panelWin;
    public GameObject panelLose;
    public GameObject paneHowToPlay;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1;
        panelWin.SetActive(false);
        panelLose.SetActive(false);
    }

    public void DisplayHowToPlay()
    {
        paneHowToPlay.SetActive(true);
    }
    public void DisplayHowToPlayOff()
    {
        paneHowToPlay.SetActive(false);
    }

    //Loads a selected scene (in editor)
    public void MyLoadScene(int idScene)
    {
        SceneManager.LoadScene(idScene);
    }

    //Quits the game
    public void doExitGame()
    {
        Application.Quit();
    }


}
