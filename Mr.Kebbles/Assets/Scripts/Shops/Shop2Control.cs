using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Shop2Control : MonoBehaviour
{
    //kebble
    float kebbleAmount;

    //sold
    float isCaneSold;
    float isDonutSold;
    float isMacSold;
    public static float isWatermelonUnlocked;

    //worth/price of items
    //original worth of first page items = 2500
    float caneWorth = 5000f;
    float donutWorth = 7500f;
    float macWorth = 10000f;

    //text 
    public Text kebbleAmountText;
    public Text unlockedText;
    public Text highScoreText;

    //public Text treePrice;
    //public Text iglooPrice;
    //public Text orbPrice;

    //buy buttons for items
    public Button caneBuyButton;
    public Button donutBuyButton;
    public Button macBuyButton;

    //equip buttons for items
    public Button caneEquipButton;
    public Button donutEquipButton;
    public Button macEquipButton;

    //unequip buttons for items
    public Button caneUnequipButton;
    public Button donutUnequipButton;
    public Button macUnequipButton;

    // review of player data
    void Start()
    {
        kebbleAmount = PlayerPrefs.GetFloat("KebblePoints");
        ScoreManager.highScoreCount = PlayerPrefs.GetFloat("HighScore");
        
        // calling for player data
        isCaneSold = PlayerPrefs.GetFloat("IsCaneSold");
        isDonutSold = PlayerPrefs.GetFloat("IsDonutSold");
        isMacSold = PlayerPrefs.GetFloat("IsMacSold");
        
        isWatermelonUnlocked = PlayerPrefs.GetFloat("IsWatermelonUnlocked");
    }

    // Update is called once per frame
    void Update()
    {
        kebbleAmountText.text = "" + Mathf.Floor(kebbleAmount);
        highScoreText.text = "High Score: " + Mathf.Floor(ScoreManager.highScoreCount);

        // calling for player data
        isCaneSold = PlayerPrefs.GetFloat("IsCaneSold");
        isDonutSold = PlayerPrefs.GetFloat("IsDonutSold");
        isMacSold = PlayerPrefs.GetFloat("IsMacSold");
        isWatermelonUnlocked = PlayerPrefs.GetFloat("IsWatermelonUnlocked");
        ScoreManager.highScoreCount = PlayerPrefs.GetFloat("HighScore");

        //unlock button interaction
        if (ScoreManager.highScoreCount >= 350)
        {
            PlayerPrefs.SetFloat("IsWatermelonUnlocked", 1);
            unlockedText.text = "UNLOCKED";
            Debug.Log("Unlocked");
        }
        else
            unlockedText.text = "LOCKED";

        //buy button interaction 
        if (kebbleAmount >= caneWorth && kebbleAmount > 0 && isCaneSold == 0)
            caneBuyButton.interactable = true;
        else
            caneBuyButton.interactable = false;
        if (kebbleAmount >= donutWorth && kebbleAmount > 0 && isDonutSold == 0)
            donutBuyButton.interactable = true;
        else
            donutBuyButton.interactable = false;
        if (kebbleAmount >= macWorth && kebbleAmount > 0 && isMacSold == 0)
            macBuyButton.interactable = true;
        else
            macBuyButton.interactable = false;


        //equip button interaction
        if (isCaneSold == 1)
            caneEquipButton.interactable = true;
        else
            caneEquipButton.interactable = false;
        if (isDonutSold == 1)
            donutEquipButton.interactable = true;
        else
            donutEquipButton.interactable = false;
        if (isMacSold == 1)
            macEquipButton.interactable = true;
        else
            macEquipButton.interactable = false;

        //unequip button interaction
        if (isCaneSold == 2)
            caneUnequipButton.interactable = true;
        else
            caneUnequipButton.interactable = false;
        if (isDonutSold == 2)
            donutUnequipButton.interactable = true;
        else
            donutUnequipButton.interactable = false;
        if (isMacSold == 2)
            macUnequipButton.interactable = true;
        else
            macUnequipButton.interactable = false;
    }

    //buy = set to 1
    public void buyCane()
    {
        kebbleAmount -= caneWorth;
        PlayerPrefs.SetFloat("IsCaneSold", 1);
    }
    public void buyDonut()
    {
        kebbleAmount -= donutWorth;
        PlayerPrefs.SetFloat("IsDonutSold", 1);
    }
    public void buyMac()
    {
        kebbleAmount -= macWorth;
        PlayerPrefs.SetFloat("IsMacSold", 1);
    }

    ////equip = set to 2
    public void equipCane()
    {
        PlayerPrefs.SetFloat("IsCaneSold", 2);
        caneEquipButton.interactable = false;
    }
    public void equipDonut()
    {
        PlayerPrefs.SetFloat("IsDonutSold", 2);
        donutEquipButton.interactable = false;
    }
    public void equipMac()
    {
        PlayerPrefs.SetFloat("IsMacSold", 2);
        macEquipButton.interactable = false;
    }
    //unequip = set to 1
    public void unequipCane()
    {
        PlayerPrefs.SetFloat("IsCaneSold", 1);
        caneUnequipButton.interactable = false;
    }
    public void unequipDonut()
    {
        PlayerPrefs.SetFloat("IsDonutSold", 1);
        donutUnequipButton.interactable = false;
    }
    public void unequipMac()
    {
        PlayerPrefs.SetFloat("IsMacSold", 1);
        macUnequipButton.interactable = false;
    }

    public void exitShop()
    {
        PlayerPrefs.SetFloat("KebblePoints", kebbleAmount);
        SceneManager.LoadScene(0);
    }
    public void resetPlayerPrefs()
    {
        kebbleAmount = 20;

        //treePrice.text = "" + treeWorth;
        //iglooPrice.text = "" + iglooWorth;
        //orbPrice.text = "" + treeWorth;
        PlayerPrefs.SetFloat("IsCaneSold", 0);
        PlayerPrefs.SetFloat("IsDonutSold", 0);
        PlayerPrefs.SetFloat("IsMacSold", 0);
        PlayerPrefs.SetFloat("IsWatermelonUnlocked", 0);
        
    }
}