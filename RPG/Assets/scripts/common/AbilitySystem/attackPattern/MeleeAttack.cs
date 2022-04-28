using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : Attack
{
    private Weapon weapon;
    public MeleeAttack(GameObject user)
    {
        weapon = user.transform.Find("weapon").gameObject.GetComponent<Weapon>();
    }

    public override void StartAttack()
    {
        base.StartAttack();
        weapon.hitBox.enabled=true;
       
    }
    public override void EndAttack()
    {
        
        weapon.hitBox.enabled=false;
        base.EndAttack();
    }
}
