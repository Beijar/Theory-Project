using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseCharacter
{
    //TODO: Add state machine for enemies
    private void Awake()
    {
        //INHERITANCE
        maxHealth = 200;
        characterName = "Bringer of Death";
    }
}
