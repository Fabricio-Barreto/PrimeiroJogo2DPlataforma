using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thwomp : MonoBehaviour
{
    public float speed;
    public float moveTime;
    public bool vertical = true;
    public bool horizontal = false;
    public bool animationdownup = true;

    private bool dirRight;
    private float timer;
    private Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (horizontal)
        {
            if (dirRight)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }

            timer += Time.deltaTime;
            if (timer >= moveTime)
            {
                dirRight = !dirRight;
                timer = 0f;
            }
        }

        if (vertical)
        {
            if (dirRight)
            {
                if (animationdownup)
                {
                    animator.SetBool("crushing", false);
                    animator.SetBool("idle", true);
                } 
                else
                {
                    animator.SetBool("idle", false);
                    animator.SetBool("crushing", true);
                }

                transform.Translate(Vector2.up * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.down * speed * Time.deltaTime);
            }


            timer += Time.deltaTime;
            if (timer >= moveTime)
            {
                if (animationdownup)
                {
                    animator.SetBool("idle", false);
                    animator.SetBool("crushing", true);
                }
                else
                {
                    animator.SetBool("crushing", false);
                    animator.SetBool("idle", true);
                }


                dirRight = !dirRight;
                timer = 0f;
            }
        }
    }

}

