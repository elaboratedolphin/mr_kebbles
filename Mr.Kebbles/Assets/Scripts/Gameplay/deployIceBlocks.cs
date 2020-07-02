using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployIceBlocks : MonoBehaviour
{
    public GameObject icePillarPrefab;
    public static float respawnTime = 1f;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(iceWave());
    }

    private void spawnIceBlocks()
    {
        GameObject a = Instantiate(icePillarPrefab) as GameObject;
        a.transform.position = new Vector2(15, Random.Range(-screenBounds.y, screenBounds.y));
    }
    IEnumerator iceWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnIceBlocks();
        }
    }
}
