using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBulletScript : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed = 20f;
    public Sprite explodedShipImage;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = Vector2.down * speed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Wall":
                Destroy(gameObject);
                break;
            case "Player":
                foreach (var item in SoundManager.Instance.SpaceAudios)
                {
                    if (item.name == "ShipExplosion")
                    {
                        SoundManager.Instance.PlayOneShot(item);
                        break;
                    }
                }
                collision.GetComponent<SpriteRenderer>().sprite = explodedShipImage;

                Destroy(gameObject);
                DestroyObject(collision.gameObject, 0.5f);
                GameOverScript.isPlayerDead = true;
                break;
            case "Shield":
                Destroy(gameObject);
                DestroyObject(collision.gameObject);
                break;
        }
    }
    
    private void OnBecomeInvisible()
    {
        Destroy(gameObject);
    }
}
