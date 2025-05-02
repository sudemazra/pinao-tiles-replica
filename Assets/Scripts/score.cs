using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class score : MonoBehaviour
{
    public TextMeshProUGUI myText;
    public static int scorePoints = 0;
    public int scoree = 0;
    public void scoreUpdate(int score)
    {
        scoree += score;
        scorePoints = scoree;
        myText.text = scoree.ToString("0");
    }

}
