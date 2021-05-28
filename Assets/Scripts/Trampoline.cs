using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{

    public float forceTrampoline;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            anim.SetTrigger("jump");
            Player.instance.isJumping = true;
            Player.instance.doubleJump = false;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, forceTrampoline), ForceMode2D.Impulse);
        }
    }
}
