using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class lastScore : MonoBehaviour
{
    public TextMeshProUGUI myText;
    public static int scorePoints = 0; //neden static?????????

    void Start()
    {
        int finalScore = score.scorePoints;
        scorePoints = score.scorePoints;
        myText.text = scorePoints.ToString("0");

    }

    void Update()
    {
        
    }
}
