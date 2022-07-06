using System.Collections;
using UnityEngine;

[System.Serializable]
public abstract class Attack
{
    /// <����������_����������_��_��������������>
    public AttackStats Property=new AttackStats();
    public Shift Shift=new Shift();
    /// </����������_����������_��_��������������>
    protected abstract void StartAttack();

    public  IEnumerator AttackByTime(UnitEntity unit)
    {
        Shift.SetStartTransform(unit.transform);
        unit.Improved.AddAttackEffects(Property);
        Property.Duration.Start�ountdown();
        StartAttack();

        while (!Property.Duration.IsReady)
        {
            Property.Duration.TickTime(Time.deltaTime);
            if (!Shift.AlreadyUsed && Property.Duration.CurTime() > Shift.StartTime)
            {
                // � ������ ����  ��� �� ������ ����������� �� �������� ����������. 
                Shift.Duration.Start�ountdown();
                Shift.AlreadyUsed = true;
            }

            TickTime(Time.deltaTime*unit.Improved.Amplifiers.AttackSpeedAmp);

            if (!Shift.Duration.IsReady)
            {
                Shift.Duration.TickTime(unit.Improved.Amplifiers.SpeedAmp * Time.deltaTime);
                unit.transform.position += Shift.CurDeltaPosition();
            }
            yield return null;
        }
        unit.Improved.DistractAttackEffects(Property);
        EndAttack();
        Shift.AlreadyUsed = false;
    }
    protected abstract void TickTime(float delta);
    protected abstract void EndAttack();
}
