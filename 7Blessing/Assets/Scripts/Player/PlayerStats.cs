﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public float health = 100;
    public int attack = 20;
    public int jumpPower = 5;
    public int speed = 10;
    public int lives = 3;
    public bool shurikenUnlocked = false;
    public bool doubleJumpUnlocked = false;


    public void UnlockNextPower()
    {
        if(!doubleJumpUnlocked)
        {
            doubleJumpUnlocked = true;
        }
        else if(!shurikenUnlocked)
        {
            shurikenUnlocked = true;
        }
    }
}
