using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BaseCharacter : MonoBehaviour
{
    public Animator animator;
    
    private FloatingHealthBar healthBar;
    private string m_characterName;
    private float m_maxHealth;
    private float currentHealth;
    // ENCAPSULATION
    public string characterName {
        get 
        {
            return m_characterName;
        } 
        set
        {
            if (value is string)
            {
                m_characterName = value;
            }
            else
            {
                m_characterName = "";
                Debug.LogError("");
            }
        } 
    }
    // ENCAPSULATION
    public float maxHealth { 
        get 
        { 
            return m_maxHealth; 
        }
        set {
            if (value > 0)
            {
                m_maxHealth = value;
            }
            else
            {
                m_maxHealth = 100;
                Debug.LogError("Max health cant be set to below 1");
            }
        } 
    }

    void Start()
    {
        healthBar = GetComponentInChildren<FloatingHealthBar>();

        currentHealth = maxHealth;
        if (healthBar)
        {
            healthBar.UpdateHealthBar(currentHealth, maxHealth);
        }
    }

    public void TakeDamage(float damage)
    {
        // ABSTRACTION
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
        // ABSTRACTION
        animator.SetBool("IsDead", true);
        // Disable character
        GetComponent<Rigidbody2D>().simulated = false;

        if (healthBar)
        {
            healthBar.transform.gameObject.SetActive(false);
        }

        this.enabled = false;
    }
}
