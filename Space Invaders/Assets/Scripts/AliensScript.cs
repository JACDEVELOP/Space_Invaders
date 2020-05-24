using System.Collections;
using UnityEngine;


public class AliensScript : MonoBehaviour
{
    public float speed = 10;
    public Rigidbody2D rb;
    public Sprite startingImage;
    public Sprite altImage;
    public float secBeforeSpriteChange = 0.5f;
    public GameObject alienBullet;
    public float minFireRateTime = 1.0f;
    public float maxFireRateTime = 50.0f;
    public float baseFireWaitTime = 200.0f;
    public Sprite explodedShipImage;

    private SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(1, 0) * speed;

        spriteRenderer = GetComponent<SpriteRenderer>();

        StartCoroutine(ChangeAlienSprite());

        baseFireWaitTime = baseFireWaitTime + Random.Range(minFireRateTime, maxFireRateTime);
    }

    void Turn(int direction)
    {
        Vector2 newVelocity = rb.velocity;
        newVelocity.x = speed * direction;
        rb.velocity = newVelocity;
    }

    void MoveDown()
    {
        Vector2 position = transform.position;
        position.y -= 1;
        transform.position = position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "LeftWall")
        {
            Turn(1);
            MoveDown();
        }

        if (collision.gameObject.name == "RigthWall")
        {
            Turn(-1);
            MoveDown();
        }

        if (collision.gameObject.tag == "Bullet")
        {

            foreach (var item in SoundManager.Instance.SpaceAudios)
            {
                if (item.name == "AlienDies")
                {
                    SoundManager.Instance.PlayOneShot(item);
                    Destroy(gameObject);
                    break;
                }
            }
            MoveDown();
        }
    }

    public IEnumerator ChangeAlienSprite()
    {
        while (true)
        {
            if (spriteRenderer.sprite == startingImage)
            {
                spriteRenderer.sprite = altImage;

            }
            else
            {
                spriteRenderer.sprite = startingImage;

                foreach (var item in SoundManager.Instance.SpaceAudios)
                {
                    if (item.name == "BulletFire")
                    {
                        SoundManager.Instance.PlayOneShot(item);
                        break;
                    }
                }
            }
            yield return new WaitForSeconds(secBeforeSpriteChange);
        }
    }

    private void FixedUpdate()
    {
        if (Time.time > baseFireWaitTime)
        {
            baseFireWaitTime = baseFireWaitTime + Random.Range(minFireRateTime, maxFireRateTime);

            Instantiate(alienBullet, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach (var item in SoundManager.Instance.SpaceAudios)
            {
                if (item.name == "ShipExplosion")
                {
                    SoundManager.Instance.PlayOneShot(item);
                    collision.GetComponent<SpriteRenderer>().sprite = explodedShipImage;
                    Destroy(gameObject);
                    DestroyObject(collision.gameObject, 0.5f);
                    break;
                }
            }
        }
    }
}
