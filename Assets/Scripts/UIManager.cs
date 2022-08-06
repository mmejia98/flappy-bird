using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text pointText;
    public Text finallyPoints;
    public Text maxScoreText;
    private int points;
    private int maxScore;
    // Start is called before the first frame update
    void Start()
    {
        maxScore = PlayerPrefs.GetInt("maxscore", 0);
        pointText.text = "0";
        finallyPoints.text = "0";
        maxScoreText.text = "Record: " + maxScore;
    }

    public void AddPoint(){
        points += 1;
        pointText.text = "" + points;
        finallyPoints.text = "Puntos :" + points;
        if(maxScore < points){
            PlayerPrefs.SetInt("maxscore", points);
            maxScoreText.text = "Record :" + points;
        }
    }
}
