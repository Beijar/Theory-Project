using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Enemy : BaseCharacter
{
    //TODO: Add state machine for enemies
    private void Awake()
    {
        //INHERITANCE
        maxHealth = 200;
        characterName = "Bringer of Death";
    }

    public override void Die()
    {
        // POLYMORPHISM
        base.Die();
        //TODO: Replace this with a game over screen and a option to load Start screen.
        SceneManager.LoadScene(0);
    }
}
