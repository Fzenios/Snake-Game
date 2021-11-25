using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public SpownPointScript SpownPointScript;//
    void Update()
    {
        ScoreText.text = "YOUR SCORE: " + SpownPointScript.ScoreCounter.ToString();
    }
}
