using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rig;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        rig.velocity = new Vector2(speed, rig.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.instance.PlayDeath();
        }
        else if (collision.gameObject.layer == 6)
        {
            Destroy(gameObject);
        }
    }

}
