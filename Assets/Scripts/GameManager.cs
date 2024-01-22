using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject[] targetprefabs;

    private float minx = -3.75f;
    private float miny = -3.75f;
    private float distance = 2.5f;

    private bool isgameover = false;
    private float spawnrate = 0.5f;
    private Vector3 randompos;
    public List<Vector3> spawnlist = new List<Vector3>();


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
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

    // Update is called once per frame
    void Update()
    {

    }
}
