using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    //Snuggles Collision Effect
    public GameObject hit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject h = Instantiate(hit) as GameObject;
        h.transform.position = transform.position;
        Destroy(collision.gameObject);
        this.gameObject.SetActive(false);
    }
}
