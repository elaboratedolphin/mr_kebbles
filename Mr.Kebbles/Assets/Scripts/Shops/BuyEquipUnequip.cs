using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyEquipUnequip : MonoBehaviour
{
    // Start is called before the first frame update
    static BuyEquipUnequip instance = null;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            Debug.Log("Destroy");
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
            Debug.Log("Not Destroyed");
        }
    }

    public void ToggleButton()
    {
        if (PlayerPrefs.GetFloat("isFlakeSold", 0) == 0)
        {
            PlayerPrefs.SetFloat("isFlakeSold", 1);
            //AudioListener.volume = 1
        }
        else if (PlayerPrefs.GetFloat("isFlakeSold", 1) == 1)
        {
            PlayerPrefs.SetFloat("isFlakeSold", 2);
        }
        else
        {
            PlayerPrefs.SetFloat("isFlakeSold", 0);
            //AudioListener.volume = 0
        }
    }
}
