using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Strip : AbstractStrip//����� ����� ��� ���� �������. ���� ����� �� ��������� ������ �������������� ��� ������ �� �����, �� ��� ������ ����� �������� ����
{
    [SerializeField]
    protected float current;
    protected LifeStates AtrophyActivatorState;//� ���� ������ ��� ����������� ��������� ������� ���������,��� �������� ������ �� ����������� ������� � ������ � ������������
    public Strip(float _max) : base(_max) {
    }

    public Strip(float _max, float reg, float Atrophy = 100) : base(_max)
    {
        current = max;
        this.atrophy = Atrophy;
        regen = reg;
    }
    public void Refresh() => current = max;
    public virtual void  StripTick(float deltaTime, LifeStates state)
    {
        current += regen * deltaTime;
        if (current > max)
            current = max;
        if (state == AtrophyActivatorState)
        {
            current -= atrophy * deltaTime;
        }
        if (current <= 0)
            current = 0;

    }


    public void AddToCurrent(float additional) => current += additional;
    public void DistractFromCurrent(float distracted) => current -= distracted;

    public float Current() => current;
    //public static Health operator +(Health a, float b) => return Health(a.max+b);
}
