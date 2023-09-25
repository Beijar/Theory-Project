using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BaseCharacter : MonoBehaviour
{
    public Animator animator;
    [SerializeField] FloatingHealthBar healthBar;
    [SerializeField] string characterName;
    [SerializeField] float maxHealth = 100f;
    [SerializeField] float currentHealth;


    private void Awake()
    {
        healthBar = GetComponentInChildren<FloatingHealthBar>();
    }

    void Start()
    {
        currentHealth = maxHealth;
        Debug.Log(currentHealth);
        if (healthBar)
        {
            healthBar.UpdateHealthBar(currentHealth, maxHealth);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (healthBar)
        {
            healthBar.UpdateHealthBar(currentHealth, maxHealth);
        }

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
