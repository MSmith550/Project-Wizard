using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class FireBall : MonoBehaviour
{
    private int minDamage = 2;
    private int maxDamage = 10;
    private int damage;
    private Vector3 shootDir;

    [SerializeField]
    private AudioClip audioSource;

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
        AudioSource.PlayClipAtPoint(audioSource, GameObject.FindGameObjectWithTag("Player").transform.position, 10);
        SlimeEnemy slimeEnemy = collision.GetComponent<SlimeEnemy>();
        if (slimeEnemy != null)
        {
            slimeEnemy.TakeDamage(damage);
        }
        SlimeBoss slimeBoss = collision.GetComponent<SlimeBoss>();
        if (slimeBoss != null)
        {
            slimeBoss.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
