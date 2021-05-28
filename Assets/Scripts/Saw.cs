using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{

    public float speed;
    public float moveTime;
    public bool vertical = false;
    public bool horizontal = true;

    public Transform target;

    private bool dirRight;
    private float timer;

    // Update is called once per frame
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
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.down * speed * Time.deltaTime);
            }

            timer += Time.deltaTime;
            if (timer >= moveTime)
            {
                dirRight = !dirRight;
                timer = 0f;
            }
        }
        
    
    }
}
