using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class BuffableEntity : MonoBehaviour
{
    private int size = 0;
    [SerializeField]
    private GUISkin buffBar;
    readonly List<TimedBuff> _buffs = new List<TimedBuff>();

    void Update()
    {

        for (int i=0;i<size;++i)
        {
            _buffs[i].Tick(Time.deltaTime);
            if (_buffs[i].Finished())
            {
                _buffs.RemoveAt(i);
                --size;
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
            ++size;
        }
    }
    private int IndexOf(TimedBuff Buff)
    {
        int index = -1;
        for (int i = 0; i < size; i++)
            if (Buff.Equals(_buffs[i]))
            {   
                index = i;
                return index;
            }

        return index;
    }
    private bool IsBuffContains(TimedBuff NewBuff)
    {
        for(int i=0;i<size;++i)
        {
            if (NewBuff.Equals(_buffs[i]))
                return true;
        }
        return false;
    }
    void OnGUI()
    {
        if (gameObject.tag == "Player")
        {
            
            int xBarPos = Screen.width / 3;
            int yBarPos = 3 * Screen.height / 4;
            int iconSize = 20;
            for (int i=0;i<size;++i)
            {  
                buffBar.GetStyle("ImgAndTimer").normal.background = _buffs[i].Buff.BuffImg;
                GUI.Box(new Rect(xBarPos+ (iconSize +1)* i,yBarPos, iconSize, iconSize),_buffs[i].ShowDuration(), buffBar.GetStyle("ImgAndTimer"));
                GUI.Box(new Rect(xBarPos + (iconSize + 1) * i, yBarPos, iconSize, iconSize), _buffs[i].ShowStacks(), buffBar.GetStyle("EffectStacks"));

            }
           
        }
    }
}
