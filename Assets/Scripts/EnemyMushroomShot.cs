using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMushroomShot : MonoBehaviour
{
    public float waitTime;
    public Transform attack;

    void Start()
    {
        StartCoroutine("Shoot", 2.0f);
    }

    void Update()
    {

    }

    public IEnumerator Shoot()
    {
        //Debug.Log("SHOT");
        //EnemyMushroom.instance.anim.SetBool("shoot", false);
        //EnemyMushroom.instance.anim.SetBool("idle", true);
        yield return new WaitForSeconds(waitTime);
        Instantiate(attack, transform.position, Quaternion.identity);        
        StartCoroutine("Idle");

    }

    public IEnumerator Idle()
    {
        //Debug.Log("Idle");
        //EnemyMushroom.instance.anim.SetBool("idle", false);
        //EnemyMushroom.instance.anim.SetBool("shoot",true);
        yield return new WaitForSeconds(waitTime);
        StartCoroutine("Shoot");
    }

}
