using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 2.5f;
    public Animator anim;
    public List<AudioSource> soundOnDestroy = new List<AudioSource>();

    private Collider2D collider;

    void Start()
    {
        collider = this.GetComponent<Collider2D>();
    }

    void Update()
    {
        Vector2 velocity = rb.velocity;
        velocity = new Vector2(velocity.x, speed);
        rb.velocity = velocity;


        // tap and destroy
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider == this.collider)
            {
                //animate
                anim.SetBool("Destroy", true);

                // play all sounds
                soundOnDestroy[1].Play();
                //soundOnDestroy[1].PlayDelayed(0.5f);
                /*
                foreach (AudioSource audio in soundOnDestroy)
                {
                    audio.Play();
                }
                */

                // destroy after animation is finished
                Object.Destroy(this.gameObject, 0.5f);
            }
        }
    }
}
