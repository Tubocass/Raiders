using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raid
{
    int fightersAttacking, fightersDefending;
    int targetStrength;

    public Raid(int fighters, int defenders, int strength )
    {
        fightersAttacking = fighters;
        fightersDefending = defenders;
        targetStrength = strength;
    }

    public bool Attack()
    {
        int totalDefenseStrength = (fightersDefending * targetStrength);
        return fightersAttacking >= totalDefenseStrength;
    }
}
