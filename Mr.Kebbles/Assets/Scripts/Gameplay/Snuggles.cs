using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
using UnityEditor;

public class Snuggles : MonoBehaviour
{
    public float delayTime = 1f;

    //health
    public static float health = 1f;
    public static float damage = 1f;
    //sounds
    public AudioSource flap;
    public AudioSource iceBreak;

    //hurt 
    public GameObject snugglesHurt;

    //Jump
    public static float flapAmount = 10f;
    private Rigidbody2D snugglesRigidBody2D;

    void IceHit()
    {
        health -= damage;
    }

    private void Awake()
    {
        snugglesRigidBody2D = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IceHit();
        iceBreak.Play();
        if (health < 1)
        {
            Destroy(gameObject);
            Instantiate(snugglesHurt, transform.position, transform.rotation);
            Debug.Log("collided");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            Jump();
            flap.Play();
        }
    }

    private void Jump()
    {
        snugglesRigidBody2D.velocity = Vector2.up * flapAmount;
    }
}