using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class IceBolt : MonoBehaviour
{
    private int minDamage = 3;
    private int maxDamage = 9;
    private int damage;
    private float slowSpeed = .75f;
    private Vector3 shootDir;


    public void Setup(Vector3 shootDir)
    {
        this.shootDir = shootDir;
        transform.eulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVectorFloat(shootDir));
        Destroy(gameObject, 1.5f);
    }
    private void Awake()
    {
        damage = Random.Range(minDamage, maxDamage);
    }

    private void Update()
    {
        float moveSpeed = 45f;
        transform.position += shootDir * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //AudioSource.PlayClipAtPoint(audioSource, GameObject.FindGameObjectWithTag("Player").transform.position, 10);
        SlimeEnemy slimeEnemy = collision.GetComponent<SlimeEnemy>();
        if (slimeEnemy != null)
        {
            slimeEnemy.TakeDamage(damage);
            slimeEnemy.SlowSpeed(slowSpeed);
        }
        SlimeBoss slimeBoss = collision.GetComponent<SlimeBoss>();
        if (slimeBoss != null)
        {
            slimeBoss.TakeDamage(damage);
            slimeBoss.SlowSpeed(slowSpeed);
        }

        Destroy(gameObject);
    }
}
