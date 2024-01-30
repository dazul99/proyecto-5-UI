using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject[] targetprefabs;

    private float minx = -3.75f;
    private float miny = -3.75f;
    private float distance = 2.5f;

    private bool isgameover = false;
    private float spawnrate = 1f;
    private Vector3 randompos;
    public List<Vector3> spawnlist = new List<Vector3>();

    private int score;

    private int lives;

    private UIManager uiManager;

    private int tim = 200;


    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        uiManager.Hidepanel();
        uiManager.Showmainmenu();

    }

    private Vector3 Spawnpos()
    {
        
        float spawnposx = minx + Random.Range(0, 4) * distance;
        float spawnposy = miny + Random.Range(0, 4) * distance;

        return new Vector3(spawnposx, spawnposy, 0f);
    }

    private IEnumerator SpawnTarget()
    {
        while (!isgameover)
        {
            yield return new WaitForSeconds(spawnrate);
            int obj = Random.Range(0, targetprefabs.Length);
            randompos = Spawnpos();
            while(spawnlist.Contains(randompos))
            {
               randompos = Spawnpos();
            }
            spawnlist.Add(randompos);
            Instantiate(targetprefabs[obj], randompos, targetprefabs[obj].transform.rotation);
        }
    }

    public void UpdateScore(int points)
    {
        score += points;
        uiManager.Updatescoretext(score);
    }

    public void UpdateLives(bool hurt = true)
    {
        if(hurt)
        {
            lives--;
        }

        if (lives == 0) gameover();
        uiManager.Updatelivestext(lives);
    }

    public bool IsGameover()
    {
        return isgameover;
    }

    private void gameover()
    {
        isgameover = true;
        uiManager.Updatefinal(score, tim);
    }

    private IEnumerator Updatetime()
    {
        while (!isgameover)
        {
            uiManager.Updatetimetext(tim);
            yield return new WaitForSeconds(1);
            tim--;
            if(tim <= 0) 
            { 
                gameover();
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }


    //dif 1 = Easy, dif 2 = medium, dif 3 = hard
    public void Startgame(int dif)
    {

        uiManager.hidemainmenu();

        spawnrate /= dif;
        tim = tim / dif;
        score = 0;
        UpdateScore(0);
        lives = 3;
        UpdateLives(false);

        StartCoroutine(Updatetime());
        StartCoroutine(SpawnTarget());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
