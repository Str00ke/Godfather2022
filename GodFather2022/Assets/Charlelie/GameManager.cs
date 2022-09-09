using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public RockFall[] rockFalls;

    [Header("Panels")]
    public GameObject panelWin;
    public GameObject panelLose;
    public GameObject paneHowToPlay;

    [SerializeField] private Image q;
    [SerializeField] private Image d;
    [SerializeField] private Image space;
    [SerializeField] private Image uiUp;
    [SerializeField] private Image uiDown;


    [SerializeField] private SpriteRenderer bgSr;
    [SerializeField] private List<Sprite> bgSpriteList = new List<Sprite>();
    [SerializeField] private List<Sprite> uiUpSpriteList = new List<Sprite>();
    [SerializeField] private List<Sprite> uiDownSpriteList = new List<Sprite>();
    [SerializeField] private List<Sprite> uiQSpriteList = new List<Sprite>();
    [SerializeField] private List<Sprite> uiDSpriteList = new List<Sprite>();
    [SerializeField] private List<Sprite> uiSSpriteList = new List<Sprite>();
    private List<Sprite> bgSpriteArr = new List<Sprite>();
    private List<int> uiSpriteArr = new List<int>();
    private int index = -1;

    void Awake()
    {
        instance = this;

        for (int i = 0; i < 50; i++)
        {
            int ind = Random.Range(0, bgSpriteList.Count);
            uiSpriteArr.Add(ind);
            bgSpriteArr.Add(bgSpriteList[ind]);
        }
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


    public void UpdateBackground()
    {
        index++;
        bgSr.sprite = bgSpriteArr[index];
        q.sprite = uiQSpriteList[uiSpriteArr[index]];
        d.sprite = uiDSpriteList[uiSpriteArr[index]];
        space.sprite = uiSSpriteList[uiSpriteArr[index]];
        uiDown.sprite = uiDownSpriteList[uiSpriteArr[index]];
        uiUp.sprite = uiUpSpriteList[uiSpriteArr[index]];
    }

}
