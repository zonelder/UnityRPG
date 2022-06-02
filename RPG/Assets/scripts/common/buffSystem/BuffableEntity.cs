using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class BuffableEntity : MonoBehaviour
{
    private int _size = 0;
    private readonly List<TimedBuff> _buffs = new List<TimedBuff>();


    public int Size() => _size;
    public TimedBuff this[int index]
    {
        get
        {
            if (index < 0 || index >= _size)
                throw new System.IndexOutOfRangeException();
            else
                return _buffs[index];
        }
    }

    private void Update()
    {

        for (int i=0;i<_size;++i)
        {
            _buffs[i].Tick(Time.deltaTime);
            if (_buffs[i].Finished())
            {
                _buffs.RemoveAt(i);
                --_size;
            }
        }
    }
    public void AddBuff(TimedBuff buff)
    {
        if (this.IsBuffContains(buff))
        {
            _buffs[IndexOf(buff)].Activate();
        }
        else
        {
            _buffs.Add(buff);
            buff.Activate();
            ++_size;
        }
    }
    private int IndexOf(TimedBuff Buff)
    {
        int index = -1;
        for (int i = 0; i < _size; i++)
            if (Buff.Equals(_buffs[i]))
            {   
                index = i;
                return index;
            }

        return index;
    }
    private bool IsBuffContains(TimedBuff NewBuff)
    {
        for(int i=0;i<_size;++i)
        {
            if (NewBuff.Equals(_buffs[i]))
                return true;
        }
        return false;
    }

}
