using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int ScoreModel = 0;
    public int AddStep = 1;
    
    public UnityEngine.UI.Text ScoreRepresentation;

    void Start()
    {
        ResetScore();
    }

    private void UpdateScoreLabel()
    {
        ScoreRepresentation.text = ScoreModel.ToString();
    }

    public void ResetScore()
    {
        ScoreModel = 0;
        UpdateScoreLabel();
    }

    public void AddScore()
    {
        ScoreModel += AddStep;
        UpdateScoreLabel();
    }

    public void AddScore(int valueToAdd)
    {
        ScoreModel += valueToAdd;
        UpdateScoreLabel();
    }


}
