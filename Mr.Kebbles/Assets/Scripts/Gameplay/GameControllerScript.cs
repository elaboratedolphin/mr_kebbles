using UnityEngine;


public class GameControllerScript : MonoBehaviour
{
    //kebble
    public static float kebbleAmount;

    //shop 1
    //public Text moneyText;
    float isTreeSold;
    float isIglooSold;
    float isOrbSold;
    
    //game objects
    public GameObject treeBuff;
    public GameObject iglooHat;
    public GameObject snowOrb;
    public GameObject loveFlake;

    //particles system game objects
    public ParticleSystem flakes;
    public ParticleSystem orbs;
    public ParticleSystem watermelon;

    //shop 2
    //public Text moneyText;
    float isCaneSold;
    float isDonutSold;
    float isMacSold;

    //game objects
    public GameObject caneBuff;
    public GameObject donutBuff;
    public GameObject macBuff;
    public GameObject watermelonBuff;



    // Start is called before the first frame update
    void Start()
    {
        //shop 1
        kebbleAmount = PlayerPrefs.GetFloat("KebbleAmount");
        isTreeSold = PlayerPrefs.GetFloat("IsTreeSold");
        isIglooSold = PlayerPrefs.GetFloat("IsIglooSold");
        isOrbSold = PlayerPrefs.GetFloat("IsOrbSold");
        ShopControlScript.isFlakeUnlocked = PlayerPrefs.GetFloat("isFlakeUnlocked");
       
        
        //shop 2
        isCaneSold = PlayerPrefs.GetFloat("IsCaneSold");
        isDonutSold = PlayerPrefs.GetFloat("IsDonutSold");
        isMacSold = PlayerPrefs.GetFloat("IsMacSold");
        Shop2Control.isWatermelonUnlocked = PlayerPrefs.GetFloat("IsWatermelonUnlocked");

        //unlockable items set active
        if (ShopControlScript.isFlakeUnlocked == 1 && isTreeSold == 2)
        {
            loveFlake.SetActive(true);
            flakeHealthBuff();
            flakes.Play();
        }
        else
            loveFlake.SetActive(false);

        if (Shop2Control.isWatermelonUnlocked == 1)
        {
            Debug.Log("if statement read");
            watermelonBuff.SetActive(true);
            watermelonHighScoreBuff();
            watermelon.Play();
        }
        else
        {
            watermelonBuff.SetActive(false);
            Debug.Log("watermelon buff not successful");
        }
        

        // 0 = no item
        // 1 = item bought and inside equipment bag
        // 2 = item equipped

        //shop 1 items set active
        if (isTreeSold == 2)
        {
            treeBuff.SetActive(true);
            flakes.Play();
            treebrellaBuff();
        }
        else
            treeBuff.SetActive(false);

        if (isIglooSold == 2)
        {
            iglooHat.SetActive(true);
            iglooBuff();
        }
        else
            iglooHat.SetActive(false);
        if (isOrbSold == 2)
        {
            snowOrb.SetActive(true);
            orbBuff();
            orbs.Play();
        }
        else
            snowOrb.SetActive(false);

        
        //shop 2 buffs set active
        if (isCaneSold == 2)
        {
            caneBuff.SetActive(true);
            caneKebsBuff();
        }
        else
            caneBuff.SetActive(false);

        if (isDonutSold == 2)
        {
            donutBuff.SetActive(true);
            donutFlapBuff();
        }
        else
            donutBuff.SetActive(false);
        if (isMacSold == 2)
        {
            macBuff.SetActive(true);
            macScoreBuff();
        }
        else
            macBuff.SetActive(false);
    }

    //shop 1
    //health +1  (flake buff)
    private void flakeHealthBuff()
        {
            Snuggles.health = 2;
            Debug.Log("flake buff successful");
        }
    //respawn 1 -> 1.1 (igloo buff)
    private void iglooBuff()
    {
        deployIceBlocks.respawnTime = 1.10f;
        Debug.Log("igloo buff successful");
    }
    //ice speed 11.5f --> 10.5f
    private void treebrellaBuff()
    {
        Ice.speed = 10.5f;
        Debug.Log("tree buff successful");
    }
    //ice block destory chance 1%
    private void orbBuff()
    {
        Ice.destroyChance = 1f;
        Debug.Log("orb buff successful");
    }

    //shop 2
    private void watermelonHighScoreBuff()
    {
        ScoreManager.highScoreLimit = 500;
        Debug.Log("watermelon buff successful");
    }
    private void caneKebsBuff()
    {
        ScoreManager.kebsPointsPerSecond = 1.4f;
        Debug.Log("cane buff successful");
    }
    private void donutFlapBuff()
    {
        Snuggles.flapAmount = 9f;
        Debug.Log("donut buff successful");
    }
    private void macScoreBuff()
    {
        ScoreManager.scorePointsPerSecond = 1.2f;
        Debug.Log("mac buff successful");
    }
    
}
