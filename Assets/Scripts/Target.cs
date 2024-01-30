using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    [SerializeField] private float selfdes = 2f;

    [SerializeField] private int points;

    [SerializeField] private GameObject particles;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        
        Destroy(gameObject, selfdes);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (!gameManager.IsGameover())
        {
            Instantiate(particles, transform.position, Quaternion.identity);
            gameManager.UpdateScore(points);
            if (gameObject.CompareTag("Bad")) gameManager.UpdateLives();
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        gameManager.spawnlist.Remove(gameObject.transform.position);
    }

}
