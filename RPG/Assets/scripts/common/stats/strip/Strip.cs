using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Strip : AbstractStrip//общий класс для всех полосок. если позже не появиться особых взаимодействий для каздой из полос, то все классы будут заменены этим
{
    [SerializeField]
    protected float current;
    protected LifeStates AtrophyActivatorState;//в этом классе нет возможности становить таковое состояние,это делается только из производных классов и только в конструкторе
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
