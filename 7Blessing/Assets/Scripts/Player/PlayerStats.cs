using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public float health = 100;
    public int attack = 20;
    public int jumpPower = 7;
    public int speed = 10;
    public int defense = 0;

    public void AddAttackPower(int attackPowerToAdd)
    {
        attack += attackPowerToAdd;
    }

    public void AddDefense(int defenseToAdd)
    {
        defense += defenseToAdd;
    }
}
