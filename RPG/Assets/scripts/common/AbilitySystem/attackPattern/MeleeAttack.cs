using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : Attack
{
    private Weapon _weapon;
    public MeleeAttack(GameObject user)
    {
        _weapon = user.transform.Find("weapon").gameObject.GetComponent<Weapon>();
    }

    public override void StartAttack()
    {
        _weapon.ActivateHitBox();
        _weapon.Sheath.PullWeapon();
    }
    public override void TickTime(float delta,float speedAmp=1)
    {

    }
    public override void EndAttack()
    {
        _weapon.DeactivateHitBox();
        _weapon.Sheath.PlaceWeapon();  
    }
}
