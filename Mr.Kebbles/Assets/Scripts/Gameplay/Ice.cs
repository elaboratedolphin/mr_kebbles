using UnityEngine;

public class Ice : MonoBehaviour
{
    public static float speed = 11.5f;
    private Rigidbody2D iceblock;
    private float xBounds = -12f;

    static float iceHealth = 1f;
    static float iceDamage = 1f;

    //public AudioSource particleCollisionNoise;
    //public AudioSource particleBounceOffNoise;


    
    public static float destroyChance = 0f;

    void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        iceblock = this.GetComponent<Rigidbody2D>();
        iceblock.velocity = new Vector2(-speed, 0);
    }

    void iceHit()
    {
        iceHealth -= iceDamage;
    }


    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < xBounds)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        iceHit();
        if (iceHealth < 1f)
        {
            Destroy(gameObject);
        }
    }

    void OnParticleCollision(GameObject other)
    {

        //particleBounceOffNoise.Play();
        if (Random.Range(0, 100) <= destroyChance)
        {
            Destroy(gameObject);
            //particleCollisionNoise.Play();
        }
    }
}
