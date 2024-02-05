using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointstext;

    [SerializeField] private TextMeshProUGUI livestext;

    [SerializeField] private TextMeshProUGUI final;
    [SerializeField] private TextMeshProUGUI goodfinal;

    [SerializeField] private TextMeshProUGUI finaltime;

    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject timeup;
    [SerializeField] private GameObject mainmenu;
    [SerializeField] private GameObject pause;

    [SerializeField] private TextMeshProUGUI timetext;

    [SerializeField] private Button easy;
    [SerializeField] private Button medium;
    [SerializeField] private Button hard;

    [SerializeField] private Button retrygood;

    [SerializeField] private Button retrybad;

    [SerializeField] private Button conti;
    [SerializeField] private Button giveup;

    [SerializeField] private Button pausebutton;

    private GameManager gamemanager;
    private void Start()
    {
        gamemanager = FindObjectOfType<GameManager>();
        easy.onClick.AddListener(() => { gamemanager.Startgame(1); });
        medium.onClick.AddListener(() => { gamemanager.Startgame(2); });
        hard.onClick.AddListener(() => { gamemanager.Startgame(4); });
        retrygood.onClick.AddListener(() => { gamemanager.Restart(); });
        retrybad.onClick.AddListener(() => { gamemanager.Restart(); });
        giveup.onClick.AddListener(() => { Time.timeScale = 1; gamemanager.Restart(); });
        conti.onClick.AddListener(() => { gamemanager.Unpause(); });
        pausebutton.onClick.AddListener(() => { gamemanager.Pause(); });
    }

    public void Updatescoretext(int score)
    {
        pointstext.text = @"Score
" + score;
    }

    public void Updatelivestext(int lives) 
    {
        string live = "";
        for (int i = 0; i < lives; i++)
        {
            live += "X ";
        }
        if (lives == 0) livestext.text = "YOU LOSE";
        else
        {
            livestext.text = @"LIVES
" + live;
        }
    }

    public void Updatefinal( int score, int tim)
    {
        timetext.text = @"Timer
" + tim;

        if (tim == 0)
        {
            goodfinal.text = @"Final Score
" + score;
            timeup.SetActive(true);
        }
        else
        {
            final.text = @"Final Score
" + score;
            finaltime.text = @"Time left
" + tim;
            panel.SetActive(true);
        }
    }

    public void Hidepanel()
    {
        panel.SetActive(false);
        timeup.SetActive(false);
        pause.SetActive(false);
    }

    public void Showmainmenu()
    {
        mainmenu.SetActive(true);
    }

    public void hidemainmenu()
    {
        mainmenu.SetActive(false);
    }

    public void Updatetimetext(int tim)
    {
        timetext.text = @"Timer
" + tim;
    }

    public void Pausemenu()
    {
        pause.SetActive(true);
    }

    public void Escapepause()
    {
        pause.SetActive(false);
    }
}
