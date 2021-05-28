using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMushroom : MonoBehaviour
{
    public float jumpForce;

    bool playerDestroyed;
    public Transform headPoint;

    private Rigidbody2D rig;
    public Animator anim;
    public BoxCollider2D boxCollider2D;

    public static EnemyMushroom instance;


    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        instance = this;
    }


    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            float height = collision.contacts[0].point.y - headPoint.position.y;

            if (height > 0 && !playerDestroyed)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                anim.SetTrigger("die");
                boxCollider2D.enabled = false;
                rig.bodyType = RigidbodyType2D.Kinematic;

                Destroy(gameObject, 0.5f);
            }
            else
            {
                playerDestroyed = true;
                Player.instance.PlayDeath();
            }
        }
    }
}
