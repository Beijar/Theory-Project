using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : BaseCharacter
{
    public int health = 100;
    public float speed = 20f;

    public Enemy() : base(100, "Bringer of Doom") { }
}
