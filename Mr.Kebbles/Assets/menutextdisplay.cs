using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menutextdisplay : MonoBehaviour
{
    public Text highScoreCount;
    public Text gamePoints;
    // Start is called before the first frame update
    void Start()
    {
        highScoreCount.text = "High Score: " + Mathf.Floor(PlayerPrefs.GetFloat("HighScore"));
        gamePoints.text = "" + Mathf.Floor(PlayerPrefs.GetFloat("KebblePoints"));
    }
}
