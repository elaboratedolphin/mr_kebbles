using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyEquipUnequipButton : MonoBehaviour
{
    private BuyEquipUnequip BuyEquipUnequip;
    public Button shopToggleButton;
    public Sprite buyOnSprite;
    public Sprite equipOnSprite;
    public Sprite unequipOnSprite;

    // Start is called before the first frame update
    void Start()
    {
        BuyEquipUnequip = GameObject.FindObjectOfType<BuyEquipUnequip>();
        UpdateIconAndSet();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void toggle()
    {
        BuyEquipUnequip.ToggleButton();
        UpdateIconAndSet();
    }

    void UpdateIconAndSet()
    {
        if (PlayerPrefs.GetFloat("isFlakeSold", 0) == 0)
        {
            PlayerPrefs.SetFloat("isFlakeSold", 1);
            shopToggleButton.GetComponent<Image>().sprite = buyOnSprite;
        }
        else if (PlayerPrefs.GetFloat("isFlakeSold', 1") == 1)
        {
            PlayerPrefs.SetFloat("isFlakeSold", 2);
            shopToggleButton.GetComponent<Image>().sprite = equipOnSprite;
        }
        else
        {
            PlayerPrefs.SetFloat("isFlakeSold", 0);
            shopToggleButton.GetComponent<Image>().sprite = unequipOnSprite;
        }
    }
}
