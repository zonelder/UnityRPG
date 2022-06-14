using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Attack
{
    /// <����������_����������_��_��������������>
    public AttackStats Property=new AttackStats();
    public Shift Shift=new Shift();
    /// </����������_����������_��_��������������>
    public abstract void StartAttack();

    public virtual IEnumerator AttackByTime(UnitStats unit)
    {
        Shift.SetStartTransform(unit.transform);
        unit.Improved.AddAttackEffects(Property);
        Property.Duration.Start�ountdown();
        StartAttack();

        while (!Property.Duration.IsReady)
        {
            // ������ ��������� �� ������ ������ �� ����� �� � ������ �� �����, �� �����  � ��
            float finalSpeedAmp =Property.SpeedAmp;
            Property.Duration.TickTime(Time.deltaTime);
            if (!Shift.AlreadyUsed && Property.Duration.CurTime() > Shift.StartTime)
            {
                // � ������ ����  ��� �� ������ ����������� �� �������� ����������. 
                Shift.Duration.Start�ountdown();
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
