using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Activator
{
    public static void ActivateAbility(ActiveAbility ability)
    {

    }

    public static void ActivateAttack(Attack attack)
    {
        attack.StartAttack();
    }
}
