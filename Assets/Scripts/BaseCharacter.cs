using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    public Animator animator;
    public string characterName;
    public int maxHealth { get; set; }
    int currentHealth;

    public BaseCharacter(int health, string name)
    {
        maxHealth = health;
        characterName = name;
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        animator.SetBool("IsDead", true);
        // Disable character
        GetComponent<Rigidbody2D>().simulated = false;
        this.enabled = false;
    }
}
