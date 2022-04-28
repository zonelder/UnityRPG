using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
public class AbstractStrip
{
    [SerializeField]
    protected float max;
    [SerializeField]
    protected float regen;//unit per second
    protected float atrophy;//unit per second

    public AbstractStrip(float max)
    {
        this.max = max;
        regen = 0;
        atrophy = 100;
    }

    public AbstractStrip(float _max, float reg, float Atrophy = 100)
    {
        max = _max;
        this.atrophy = Atrophy;
        regen = reg;
    }
    public float Max() => max;
    public float Regen() => regen;
    public float Atrophy() => atrophy;
    public void AddToMax(float additional) => max += additional;
    public void AddRegen(float additional) => regen += additional;


}
