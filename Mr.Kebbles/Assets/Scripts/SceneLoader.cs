using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class SceneLoader : MonoBehaviour
{



public void LoadNextScene ()
    {
        
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void ReverseLoadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex - 1);
    }

    public void LoadShopOne()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadStartScreen()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadShopTwo()
    {
        SceneManager.LoadScene(4);
    }
    // Start is called before the first frame update
}
