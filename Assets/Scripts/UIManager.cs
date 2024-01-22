using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointstext;

    private int score;

    private void Start()
    {
        pointstext.text = @"Score
" + score;
    }
}
