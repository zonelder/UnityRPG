using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShiftStatus
{
    BEFORE_SHIFT,
    IN_SHIFT,
    AFTER_SHIFT
}
public enum AttackStatus
{
    OUT_ATTACK,
    IN_ATTACK,
}


public class AttackManager//хранит все что связано с логикой поведения во время атаки. что и когда должно происходит за вычетом забовых вещей
{
    public AttackStatus attackStatus;
    public ShiftStatus shiftStatus;

    public AttackManager()
    {
        attackStatus = AttackStatus.OUT_ATTACK;
        shiftStatus =ShiftStatus.BEFORE_SHIFT;
    }

    /*
     if (manager.attackStatus == AttackStatus.IN_ATTACK)
        {
            if(!property.duration.IsReady())
            property.duration.TickTime(delta);
            else
            {
                manager.attackStatus = AttackStatus.OUT_ATTACK;
            }


            if(manager.shiftStatus==ShiftStatus.BEFORE_SHIFT && property.duration.curTime() > shift.startTime)
            //if (!shift.alreadyUsed && property.duration.curTime() > shift.startTime)// в случае если  еще не юзалос перемещение то начинаем перемещать 
            {
                manager.shiftStatus = ShiftStatus.IN_SHIFT;
                shift.duration.StartСountdown();
              //  shift.alreadyUsed = true;
            }
            if (manager.shiftStatus == ShiftStatus.IN_SHIFT)
            {
                shift.duration.TickTime(finalSpeedAmp * delta);
                if (shift.duration.IsReady())//стал готов после тика
                    manager.shiftStatus = ShiftStatus.AFTER_SHIFT;
            }
        }
        if(manager.attackStatus == AttackStatus.OUT_ATTACK)
        {
            EndAttack();
        }
     */
}
