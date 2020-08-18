﻿using UnityEngine;
using Pathfinding;

public class SlimeEnemy : MonoBehaviour
{
    private int maxHealth = 10;
    private int currentHealth;
    public int damage = 5;
    public GameObject itemDropped; 

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; 
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            Instantiate(itemDropped, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    public void SlowSpeed(float slowSpeed)
    {
        AIPath aiPath = GetComponent<AIPath>();
        aiPath.maxSpeed = (aiPath.maxSpeed * slowSpeed);
    }
}
