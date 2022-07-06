using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : Attack
{
    private Weapon _weapon;
    public Shift _weaponTrajectory;
    public MeleeAttack(GameObject user)
    {
        _weapon = user.transform.Find("weapon").GetComponent<Weapon>();
        _weaponTrajectory = new Shift();
        //_weaponTrajectory.trajectory.MoveKey(1,1,Vector3.forward);
    }

    protected sealed override void StartAttack()
    {
        _weapon.ActivateHitBox();
        _weaponTrajectory.SetStartTransform(_weapon.transform);
    }
    protected sealed override void TickTime(float delta)
    {
     /*
     /// это все ужастно и нечитабельно. тут уже достаточно высокий уровень абстракции. должно быть лучше
        if (!_weaponTrajectory.AlreadyUsed && Property.Duration.CurTime() >_weaponTrajectory.StartTime)
        {
            // В случае если  еще не юзалос перемещение то начинаем перемещать. 
            _weaponTrajectory.Duration.StartСountdown();
            _weaponTrajectory.AlreadyUsed = true;
        }

        if (!_weaponTrajectory.Duration.IsReady)
        {
            
            _weaponTrajectory.Duration.TickTime(Time.deltaTime);
            _weapon.transform.position +=_weaponTrajectory.CurDeltaPosition();
        }
     */
    }
    protected sealed override void EndAttack()
    {
        _weapon.DeactivateHitBox();
    }
}
