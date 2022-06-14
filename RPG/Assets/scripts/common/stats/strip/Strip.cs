using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void StripMethod();

[System.Serializable]
public class Strip : AbstractStrip
{
    public event StripMethod OnStripOver;
    public event StripMethod OnStripFull;

    [SerializeField]
    private float _current;
    private bool atrophyWork;
    public Strip(float _max) : base(_max) 
    {
    }

    public Strip(float _max, float reg, float Atrophy = 100) : base(_max,reg,Atrophy)
    {
        _current = Max();
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
        _current += additional;
        if (_current > Max())
        {
            _current = Max();
            OnStripFull?.Invoke();
        }
    }
    public void DistractFromCurrent(float distracted)
    {
        if (distracted < 0)
            throw new System.ArgumentException("expect positive value,but get "+distracted);
          _current -= distracted;
        if (_current <= 0)
        {
            _current = 0;
            if (!atrophyWork)
            {
                atrophyWork = true;
                OnStripOver?.Invoke();
            }
            
        }
    }

    public float Current() => _current;
}
