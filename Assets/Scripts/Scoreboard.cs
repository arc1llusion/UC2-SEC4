using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    private int score;
    private Text text;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        text.text = score.ToString("D8");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ScoreHit(int points)
    {
        score += points;
        text.text = score.ToString("D8");
    }
}
