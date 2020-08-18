using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
    private void Update()
    {
        if (currentHealth <= 0)
        {
            //player death and respawn
            SceneManager.LoadScene("Main Menu");
        }
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SlimeEnemy slimeEnemy = collision.collider.GetComponent<SlimeEnemy>();
        if (slimeEnemy != null)
        {
            takeDamage(slimeEnemy.damage);
        }
    }
}
