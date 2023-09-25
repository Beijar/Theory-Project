using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int MaxHealth = 100;
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        animator.SetBool("IsDead", true);
        // Disable enemy
        GetComponent<Rigidbody2D>().simulated = false;
        //GetComponent<BoxCollider2D>().enabled = false;
        //GetComponent<CircleCollider2D>().enabled = false;
        this.enabled = false;
    }
}
