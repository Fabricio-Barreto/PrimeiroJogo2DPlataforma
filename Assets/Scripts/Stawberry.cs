using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stawberry : MonoBehaviour
{

    private SpriteRenderer sr;
    private CircleCollider2D circle;

    public float timeCollectedSmoke;
    public int Score;
    public GameObject collected;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            sr.enabled = false;
            circle.enabled = false;
            collected.SetActive(true);

            GameController.instance.totalScore += Score;
            GameController.instance.UpdateScoreText();

            Destroy(gameObject, timeCollectedSmoke);
        }
    }
}
