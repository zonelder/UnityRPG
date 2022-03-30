using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class BuffableEntity : MonoBehaviour
{
    public int size = 0;
    public GUISkin buffBar;
    readonly List<TimedBuff> _buffs = new List<TimedBuff>();

    void Update()
    {

        for (int i=0;i<size;++i)
        {
            _buffs[i].Tick(Time.deltaTime);
            if (_buffs[i].IsFinished)
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
    public int IndexOf(TimedBuff Buff)
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
    public bool IsBuffContains(TimedBuff NewBuff)
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
        //public Tex
        if (this.tag == "Player")
        {
            
            int xBarPos = Screen.width / 3;
             int yBarPos = 3 * Screen.height / 4;
            int count = 0;
            int iconSize = 20;
            for (int i=0;i<size;++i)
            {   //Debug.Log("wanna print");
                buffBar.GetStyle("ImgAndTimer").normal.background = _buffs[i].Buff.BuffImg;
                GUI.Box(new Rect(xBarPos+ (iconSize +1)* count,yBarPos, iconSize, iconSize),_buffs[i].ShowDuration(), buffBar.GetStyle("ImgAndTimer"));
                GUI.Box(new Rect(xBarPos + (iconSize + 1) * count, yBarPos, iconSize, iconSize), _buffs[i].ShowStacks(), buffBar.GetStyle("EffectStacks"));
                count++;
            }
           
        }
        if(this.tag=="Unit")
        {

        }
        //Assets / Resources / GUI / BuffSprites / APBuff.png


    }
}
