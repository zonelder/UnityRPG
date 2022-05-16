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
    public  Level Exp;


    public BaseStats Base;
    public Stats Improved;

    private Coroutine _MPAtrophy;
    private Coroutine _HPAtrophy;

    public UnitStats(int HP, int MP, int STR, int vitality, int energy)
    {
        Base = new BaseStats(HP, MP, STR, vitality, energy);
        Exp = new Level();
        
    }

    public void OnEnable()
    {
        Improved.HP.StripOver += OnHPOver;
        Improved.MP.StripOver += OnMPOver;
    }
    public void OnDisable()
    {
        Improved.HP.StripOver -= OnHPOver;
        Improved.MP.StripOver -= OnMPOver;
    }
    protected void StartExistence()
    {
        // Вызываем в дочерних классах чтобы доформировать юнита
        Improved = new Stats(Base);
        refresh();
        
    }
    protected virtual void Start()
    {
        Time.timeScale = 1;
        state = LifeStates.STABLE;
        StartCoroutine(Improved.HP.RegenerateByTime());
        StartCoroutine(Improved.MP.RegenerateByTime());

    }
    protected virtual void Update()
    {
    }
    private void OnHPOver()
    {
        if (state == LifeStates.MIND_ON_THE_EDGE)
        {
            StopCoroutine(_HPAtrophy);
            state = LifeStates.DEAD;
        }
        else
        {
           _MPAtrophy= StartCoroutine(Improved.MP.StartAtrophy());
            state = LifeStates.BODY_ON_THE_EDGE;
        }
    }
    private void OnMPOver()
    {
        if (state == LifeStates.BODY_ON_THE_EDGE)
        {
            StopCoroutine(_MPAtrophy);
            state = LifeStates.DEAD;
        }
        else
        {
          _HPAtrophy=  StartCoroutine(Improved.HP.StartAtrophy());
            state = LifeStates.MIND_ON_THE_EDGE;

        }
    }
    public void refresh()
    {
        Improved.HP.Refresh();
        Improved.MP.Refresh();
    }

    public void GetExpFrom(UnitStats defeatedEnemy)
    {
        Exp.CatchExpirience( defeatedEnemy.Exp.DieExpirience());
    }
}
