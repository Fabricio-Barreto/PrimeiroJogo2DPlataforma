using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFrog : MonoBehaviour
{

    public float speed;
    public float jumpForce;

    private bool colliding;
    bool playerDestroyed;

    private Rigidbody2D rig;
    private Animator anim;

    public Transform rightCol;
    public Transform leftCol;
    public Transform headPoint;
    public LayerMask layer;
    public BoxCollider2D boxCollider2D;
    public CircleCollider2D circleCollider2D;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        rig.velocity = new Vector2(speed, rig.velocity.y);

        colliding = Physics2D.Linecast(rightCol.position, leftCol.position, layer);

        if(colliding)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            speed = -speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            float height = collision.contacts[0].point.y - headPoint.position.y;
            
            if(height > 0 && !playerDestroyed)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                speed = 0f;
                anim.SetTrigger("die");
                boxCollider2D.enabled = false;
                circleCollider2D.enabled = false;
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
