using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Attack
{
    /// <переменные_отвечающие_за_характеристики>
    public AttackStats Property=new AttackStats();
    public Shift Shift=new Shift();
    /// </переменные_отвечающие_за_характеристики>
    public abstract void StartAttack();

    public virtual IEnumerator AttackByTime(UnitStats unit)
    {
        Shift.SetStartTransform(unit.transform);
        unit.Improved.AddAttackEffects(Property);
        Property.Duration.StartСountdown();
        StartAttack();

        while (!Property.Duration.IsReady)
        {
            // Должно учитывать не только бонусы от атаки но и бонусы от бафов, от экипы  и тд
            float finalSpeedAmp =Property.SpeedAmp;
            Property.Duration.TickTime(Time.deltaTime);
            if (!Shift.AlreadyUsed && Property.Duration.CurTime() > Shift.StartTime)
            {
                // В случае если  еще не юзалос перемещение то начинаем перемещать. 
                Shift.Duration.StartСountdown();
                Shift.AlreadyUsed = true;
            }

            TickTime(Time.deltaTime, finalSpeedAmp);

            if (!Shift.Duration.IsReady)
            {
                Shift.Duration.TickTime(finalSpeedAmp * Time.deltaTime);
                unit.transform.position =Shift.CurPosition();
            }
            yield return null;
        }
        unit.Improved.DistractAttackEffects(Property);
        EndAttack();
        Shift.AlreadyUsed = false;
    }
    public abstract void TickTime(float delta, float finalSpeedAmp = 1);
    public abstract void EndAttack();
}
