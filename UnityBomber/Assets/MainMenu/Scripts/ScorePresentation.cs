using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePresentation : MonoBehaviour
{
    public Text txtScore;
    public Text lblScore;
    void Start ()
	{
	    if (Score.ScoreModel > 0)
	    {
	        lblScore.GetComponent<Text>().enabled = true;
            txtScore.GetComponent<Text>().enabled = true;

            txtScore.text = Score.ScoreModel.ToString();
	    }
	    else
	    {
            lblScore.GetComponent<Text>().enabled = false;
            txtScore.GetComponent<Text>().enabled = false;
        }
	}
}
