using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    [SerializeField] private TextMeshProUGUI timetext;

    private void Start()
    {
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
}
