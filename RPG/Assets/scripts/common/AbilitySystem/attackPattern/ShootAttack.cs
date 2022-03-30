using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAttack : Attack
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
