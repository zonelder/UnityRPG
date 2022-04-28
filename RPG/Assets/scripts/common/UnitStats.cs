using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using stats;
public enum LifeStates
{ 
    STABLE,
    BODY_ON_THE_EDGE,
    MIND_ON_THE_EDGE,
    DEAD,
    UNDEFINE,
}
public class UnitStats : MonoBehaviour
{
    [SerializeField]
    protected LifeStates state;
    [SerializeField]
    public   Level exp;
    public BaseStats _base = new BaseStats(0,0,0,0,0);
    [SerializeField]
    public Stats _improved = new Stats(0, 0, 0, 0, 0);

    public UnitStats(int HP, int MP, int STR, int vitality, int energy)
    {
        _base = new BaseStats(HP, MP, STR, vitality, energy);
        exp = new Level();
        
    }
    protected void StartExistence()//вызываем в дочерних классах чтобы доформировать юнита
    {
        _improved = new Stats(_base);
    }
    protected virtual void Start()
    {
        Time.timeScale = 1;
        state = LifeStates.STABLE;
        
    }
    protected virtual void Update()
    {
        if(state != LifeStates.DEAD)
        {
            _improved.HP.StripTick(Time.deltaTime,state);
            _improved.MP.StripTick(Time.deltaTime, state);
        }
        if (_improved.HP.Current() <= 0)
        {
            if (state != LifeStates.BODY_ON_THE_EDGE)
            {
                if (state == LifeStates.MIND_ON_THE_EDGE)
                    state = LifeStates.DEAD;
                else
                    state = LifeStates.BODY_ON_THE_EDGE;
            }
        }
        if (_improved.MP.Current() <= 0)
        {
            if(state!=LifeStates.MIND_ON_THE_EDGE)
            {
                if (state == LifeStates.BODY_ON_THE_EDGE)
                    state = LifeStates.DEAD;
                else
                    state= LifeStates.MIND_ON_THE_EDGE;
            }
        }         
    }

    public void refresh()
    {
        _improved.HP.Refresh();
        _improved.MP.Refresh();
    }

    public void GetExpFrom(UnitStats defeatedEnemy)
    {
        exp.CatchExpirience( defeatedEnemy.exp.DieExpirience());
    }
}
