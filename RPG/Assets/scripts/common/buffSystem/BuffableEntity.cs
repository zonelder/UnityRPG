using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class BuffableEntity : MonoBehaviour
{
    private readonly List<TimedBuff> _buffs = new List<TimedBuff>();

    public int Size => _buffs.Count;
    public TimedBuff this[int index]
    {
        get
        {
            if (index < 0 || index >= _buffs.Count)
                throw new System.IndexOutOfRangeException();
            else
                return _buffs[index];
        }
    }

    public void AddBuff(TimedBuff buff)
    {
        if (IsBuffContains(buff))
        {
            _buffs[IndexOf(buff)].Activate();
        }
        else
        {
            _buffs.Add(buff);
            buff.OnEndBuff += RemoveFirstFinished;
            buff.Activate();
        }
    }

    private void Update()
    {
        for (int i=0;i< _buffs.Count; ++i)
        {
            _buffs[i].Tick(Time.deltaTime);
        }
    }
    // Лушче сказать что баф кончается и информирует всех кого надо о том что именно он кончился
    private void RemoveFirstFinished()
    {
        for(int i=0;i<_buffs.Count;++i)
        {
            if(_buffs[i].IsFinished)
            {
                _buffs[i].OnEndBuff -= RemoveFirstFinished;
                _buffs.RemoveAt(i);
                break;
            }
        }
    }

    private int IndexOf(TimedBuff Buff)
    {
        int index = -1;
        for (int i = 0; i < _buffs.Count; i++)
            if (Buff.Equals(_buffs[i]))
            {   
                index = i;
                return index;
            }
        return index;
    }
    private bool IsBuffContains(TimedBuff NewBuff)
    {
        for(int i=0;i < _buffs.Count; ++i)
        {
            if (NewBuff.Equals(_buffs[i]))
                return true;
        }
        return false;
    }

}
