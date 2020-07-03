
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    //text
    public Text scoreText;
    public Text highScoreText;
    public Text gamePointsText;

    //variables
    float scoreCount;
    public static float highScoreCount; 
    float pointsCount;
    
    //limiters
    public static float highScoreCountLimit;
    public static float scoreCountLimit;
    public static float pointsCountLimit;
   
    //maximum
    public static float highScoreLimit = 350;
    public static float scoreLimit = 999;
    //public static float pointsLimit = 20;
    public static float kebsLimit = 50000;

    //points per second float
    public static float scorePointsPerSecond = 1f;
    public static float kebsPointsPerSecond = 1f;

    //score increasing
    public bool scoreIncreasing;

    // checks high score and snuggle points at START
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
        if (PlayerPrefs.HasKey("KebblePoints"))
        {
            pointsCount = PlayerPrefs.GetFloat("KebblePoints");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
            //calculates score if true
            if (scoreIncreasing)
        {
            scoreCount += scorePointsPerSecond * Time.deltaTime;
            pointsCount += kebsPointsPerSecond * Time.deltaTime;
            PlayerPrefs.SetFloat("KebblePoints", pointsCount);
            PlayerPrefs.SetFloat("Score", scoreCount);
        }

        //kebspoints max
        if (pointsCount >= kebsLimit)
        {
            pointsCount = kebsLimit;
            PlayerPrefs.SetFloat("KebblePoints", kebsLimit);
        }

        //score max
        if (scoreCount >= scoreLimit)
        {
            scoreCount = scoreLimit;
            PlayerPrefs.SetFloat("Score", scoreCountLimit);
        }

        if (highScoreCount >= highScoreLimit)
        {
            highScoreCount = highScoreLimit;
            PlayerPrefs.SetFloat("Highscore", highScoreLimit);
        }


        //replaces old highscore with the new current score if greater
        if(scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", highScoreCount);
        }

        //Display score at the end
        scoreText.text = "" + Mathf.Floor(scoreCount);
        highScoreText.text = "High Score: " + Mathf.Floor(highScoreCount);
        gamePointsText.text = " " + Mathf.Floor(pointsCount); 
    }
}
