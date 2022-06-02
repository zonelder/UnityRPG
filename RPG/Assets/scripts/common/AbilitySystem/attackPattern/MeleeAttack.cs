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

        weapon.ActivateHitBox();
        weapon.Sheath.PullWeapon();

    }
    public override void EndAttack()
    {

        weapon.DeactivateHitBox();
        weapon.Sheath.PlaceWeapon();
        base.EndAttack();
       
    }
}
