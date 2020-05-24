using UnityEngine;
using UnityEngine.UI;

public class BulletScript : MonoBehaviour
{
    public float speed = 30f;
    public Sprite explodedAlienImage;

    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = Vector2.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            Destroy(gameObject);
        }

        if (collision.tag == "Alien")
        {
            foreach (var item in SoundManager.Instance.SpaceAudios)
            {
                if (item.name == "AlienDies")
                {
                    SoundManager.Instance.PlayOneShot(item);
                    collision.GetComponent<SpriteRenderer>().sprite = explodedAlienImage;

                    Destroy(gameObject);

                    DestroyObject(collision.gameObject, 0.1f);
                    IncreaseTextScore();
                    break;
                }
            }
        }

        if (collision.tag == "Shield")
        {
            Destroy(gameObject);
            DestroyObject(collision.gameObject);
        }
    }

    private void OnBecomeInvisible()
    {
        Destroy(gameObject);
    }

    void IncreaseTextScore()
    {
        var textUIComp = GameObject.Find("Score").GetComponent<Text>();

        int score = int.Parse(textUIComp.text);

        score += 10;

        textUIComp.text = score.ToString();
    }
}
