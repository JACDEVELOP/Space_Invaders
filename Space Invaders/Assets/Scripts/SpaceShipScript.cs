using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipScript : MonoBehaviour
{
    public float speed = 30f;
    public GameObject bullet;

    private void FixedUpdate()
    {
        float horzMove = Input.GetAxisRaw("Horizontal");

        GetComponent<Rigidbody2D>().velocity = new Vector2(horzMove, 0) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Instantiate(bullet, transform.position, Quaternion.identity);

            foreach (var item in SoundManager.Instance.SpaceAudios)
            {
                if (item.name == "BulletFire")
                {
                    SoundManager.Instance.PlayOneShot(item);
                    break;
                }
            }
       }
    }
}
