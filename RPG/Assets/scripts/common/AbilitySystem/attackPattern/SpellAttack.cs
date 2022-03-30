using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellAttack : Attack
{
    public override void StartAttack()
    {
        isActive = true;
        //raycat
    }
    public override void EndAttack()
    {
        isActive = false;
    }
}
