using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastSceneHighScore : MonoBehaviour
{
    // Start is called before the first frame update
    public Text scoreCount;
    public Text highScoreCount;
    public Text gamePoints;

    void Start()
    {
        highScoreCount.text = "High Score: " + Mathf.Floor(PlayerPrefs.GetFloat("HighScore"));
        scoreCount.text = "Score: " + Mathf.Floor(PlayerPrefs.GetFloat("Score"));
        gamePoints.text = "Total Kebbles: " + Mathf.Floor(PlayerPrefs.GetFloat("KebblePoints"));
    }

}
