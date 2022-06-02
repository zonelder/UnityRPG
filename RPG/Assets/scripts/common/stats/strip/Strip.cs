using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Strip : AbstractStrip
{
    public event StripMethod StripOver;

    [SerializeField]
    private float current;
    private bool atrophyWork;
    public Strip(float _max) : base(_max) 
    {
    }

    public Strip(float _max, float reg, float Atrophy = 100) : base(_max,reg,Atrophy)
    {
        current = Max();
        atrophyWork=false;
    }

    public void Refresh()
    {

        AddToCurrent(Max());
        atrophyWork = false;
    }

    public IEnumerator StartAtrophy()
    {
        while(true)
        {
            DistractFromCurrent(Atrophy());
            yield return new WaitForSeconds(1.0f);
        }
    }

    public IEnumerator RegenerateByTime()
    {
        while (true)
        {
            AddToCurrent(Regen());
            yield return new WaitForSeconds(1.0f);
        }
    }
    public void  AddToCurrent(float additional)
    {
        if (additional <0)
            throw new System.ArgumentException("expect positive value,but get " + additional);
        current += additional;
        if (current > Max())
        {
            current = Max();
        }
    }
    public void DistractFromCurrent(float distracted)
    {
        if (distracted < 0)
            throw new System.ArgumentException("expect positive value,but get "+distracted);
          current -= distracted;
        if (current <= 0)
        {
            current = 0;
            if (!atrophyWork)
            {
                atrophyWork = true;
                StripOver();
            }
            
        }
    }

    public float Current() => current;
}
public delegate void StripMethod();