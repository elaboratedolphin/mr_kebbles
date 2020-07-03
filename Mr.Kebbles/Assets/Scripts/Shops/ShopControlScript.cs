
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ShopControlScript : MonoBehaviour
{
    //kebble
    float kebbleAmount;

    //sold
    float isTreeSold;
    float isIglooSold;
    float isOrbSold;
    public static float isFlakeUnlocked;

    //worth/price of items
    //original worth of first page items = 2500
    float treeWorth = 2000f;
    float iglooWorth = 2000f;
    float orbWorth = 5000f;

    //text for item prices
    public Text kebbleAmountText;
    public Text unlockedText;
    public Text highScoreText;

    //buy buttons for items
    public Button treeBuyButton;
    public Button iglooBuyButton;
    public Button orbBuyButton;

    //equip buttons for items
    public Button treeEquipButton;
    public Button iglooEquipButton;
    public Button orbEquipButton;

    //unequip buttons for items
    public Button treeUnequipButton;
    public Button iglooUnequipButton;
    public Button orbUnequipButton;

    // review of player data
    void Start()
    {
        kebbleAmount = PlayerPrefs.GetFloat("KebblePoints");

        // calling for player data
        isTreeSold = PlayerPrefs.GetFloat("IsTreeSold");
        isIglooSold = PlayerPrefs.GetFloat("IsIglooSold");
        isOrbSold = PlayerPrefs.GetFloat("IsOrbSold");
        isFlakeUnlocked = PlayerPrefs.GetFloat("IsFlakeUnlocked");
    }

    // Update is called once per frame
    void Update()
    {
        kebbleAmountText.text = "" + Mathf.Floor(kebbleAmount);
        highScoreText.text = "High Score: " + Mathf.Floor(ScoreManager.highScoreCount);

        // calling for player data
        isTreeSold = PlayerPrefs.GetFloat("IsTreeSold");
        isIglooSold = PlayerPrefs.GetFloat("IsIglooSold");
        isOrbSold = PlayerPrefs.GetFloat("IsOrbSold");
        isFlakeUnlocked = PlayerPrefs.GetFloat("IsFlakeUnlocked");
        ScoreManager.highScoreCount = PlayerPrefs.GetFloat("HighScore");

        //unlock button interaction
        if (ScoreManager.highScoreCount >= 100 && isTreeSold == 2)
        {
            PlayerPrefs.SetFloat("isFlakeUnlocked", 1);
            unlockedText.text = "UNLOCKED";
        }
        else
            unlockedText.text = "LOCKED";

        //buy button interaction 
        if (kebbleAmount >= treeWorth && kebbleAmount > 0 && isTreeSold == 0)
            treeBuyButton.interactable = true;
        else
            treeBuyButton.interactable = false;
        if (kebbleAmount >= iglooWorth && kebbleAmount > 0 && isIglooSold == 0)
            iglooBuyButton.interactable = true;
        else
            iglooBuyButton.interactable = false;
        if (kebbleAmount >= orbWorth && kebbleAmount > 0 && isOrbSold == 0)
            orbBuyButton.interactable = true;
        else
            orbBuyButton.interactable = false;


        //equip button interaction
        if (isTreeSold == 1)
            treeEquipButton.interactable = true;
        else
            treeEquipButton.interactable = false;
        if (isIglooSold == 1)
            iglooEquipButton.interactable = true;
        else
            iglooEquipButton.interactable = false;
        if (isOrbSold == 1)
            orbEquipButton.interactable = true;
        else
            orbEquipButton.interactable = false;

        //unequip button interaction
        if (isTreeSold == 2)
            treeUnequipButton.interactable = true;
        else
            treeUnequipButton.interactable = false;
        if (isIglooSold == 2)
            iglooUnequipButton.interactable = true;
        else
            iglooUnequipButton.interactable = false;
        if (isOrbSold == 2)
            orbUnequipButton.interactable = true;
        else
            orbUnequipButton.interactable = false;
    }
    
    //buy = set to 1
    public void buyTree()
    {
        kebbleAmount -= treeWorth;
        PlayerPrefs.SetFloat("IsTreeSold", 1);
        //treePrice.text = "---";
    }
    public void buyIgloo()
    {
        kebbleAmount -= iglooWorth;
        PlayerPrefs.SetFloat("IsIglooSold", 1);
        //iglooPrice.text = "---";
    }
    public void buyOrb()
    {
        kebbleAmount -= orbWorth;
        PlayerPrefs.SetFloat("IsOrbSold", 1);
        //orbPrice.text = "---";
    }

    ////equip = set to 2
    public void equipTree()
    {
        PlayerPrefs.SetFloat("IsTreeSold", 2);
        treeEquipButton.interactable = false;
    }
    public void equipIgloo()
    {
        PlayerPrefs.SetFloat("IsIglooSold", 2);
        iglooEquipButton.interactable = false;
    }
    public void equipOrb()
    {
        PlayerPrefs.SetFloat("IsOrbSold", 2);
        orbEquipButton.interactable = false;
    }
    //unequip = set to 1
    public void unequipTree()
    {
        PlayerPrefs.SetFloat("IsTreeSold", 1);
        treeUnequipButton.interactable = false;
    }
    public void unequipIgloo()
    {
        PlayerPrefs.SetFloat("IsIglooSold", 1);
        iglooUnequipButton.interactable = false;
    }
    public void unequipOrb()
    {
        PlayerPrefs.SetFloat("IsOrbSold", 1);
        orbUnequipButton.interactable = false;
    }

    public void exitShop()
    {
        PlayerPrefs.SetFloat("KebblePoints", kebbleAmount);
        SceneManager.LoadScene(0);
    }
    public void resetPlayerPrefs()
    {
        kebbleAmount = 0;
        
        //treePrice.text = "" + treeWorth;
        //iglooPrice.text = "" + iglooWorth;
        //orbPrice.text = "" + treeWorth;
        PlayerPrefs.SetFloat("IsTreeSold", 0);
        PlayerPrefs.SetFloat("IsIglooSold", 0);
        PlayerPrefs.SetFloat("IsOrbSold", 0);
        PlayerPrefs.SetFloat("IsFlakeUnlocked", 0);
        
    }
}
