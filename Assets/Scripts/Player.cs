using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float Speed;
    public float JumpForce;

    public bool isJumping;
    public bool doubleJump;

    private Rigidbody2D rig;
    private Animator anim;
    private BoxCollider2D boxCollider2D;
    private CircleCollider2D circleCollider2D;

    public static Player instance;

    bool isBlowing;

    void Start()
    {

        instance = this;

        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {

        float movement = Input.GetAxis("Horizontal");

        rig.velocity = new Vector2(movement * Speed, rig.velocity.y);

        if(movement > 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        if (movement < 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        if (movement == 0)
        {
            anim.SetBool("walk", false);
        }

    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") && !isBlowing)
        {
            if(!isJumping)
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                anim.SetBool("jump", true);
            }
            else
            {
                if (doubleJump)
                {
                    rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                    doubleJump = false;
                    anim.SetBool("doublejump", true);
                }
            }

        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = false;
            anim.SetBool("jump", false);
            anim.SetBool("doublejump", false);
        }

        if (collision.gameObject.tag == "Spike")
        {
            PlayDeath();
        }



    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = true;
        }

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 11)
        {
            isBlowing = true;
            isJumping = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Saw")
        {
            PlayDeath();
        }
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            isBlowing = false;
        }
    }

    public void PlayDeath()
    {
        GameController.instance.ShowGameOver();

        GetComponent<AudioSource>().Play();
        anim.SetBool("death", true);
        boxCollider2D.enabled = false;
        circleCollider2D.enabled = false;
        rig.bodyType = RigidbodyType2D.Kinematic;

        rig.constraints = RigidbodyConstraints2D.FreezeAll;

        Destroy(gameObject, 3f);
    }


}
