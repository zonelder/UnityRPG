using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using stats;
enum LifeStates
{ 
    BODY_ON_THE_EDGE,
    MIND_ON_THE_EDGE,
    DEAD,
    STABLE
}

public class UnitStats : MonoBehaviour
{
    public int lvl = 1;
    public float ExpToUp = 1000;
    public  bool death;
    public BaseStats _base = new BaseStats(0,0,0,0,0);
    public Stats _improved = new Stats(0, 0, 0, 0, 0);
    public float ExpForDeath;
 
    /// <current value>
    ///
    public float curHP; //кол-во жизней персонаж нынешние
    public float curMP; //кол-во маны персонажа
    public float curEXP; //кол-во опыта

    public UnitStats(int HP, int MP, int STR, int vitality, int energy)
    {
        _base.HP =HP;
        _base.MP = MP;
        _base.attributes.STR = STR;
        _base.attributes.vitality = vitality;
        _base.attributes.intellect = energy;
        //this.StartExistence();
        this.refresh();
        
    }
    public void StartExistence()//вызываем в дочерних классах в конструкторе
    {
        //заполн€ем improved;
        _improved.HP=_base.HP;//дл€ всего этого можно отдельный функци сделать
        _improved.MP = _base.MP;
        _improved.MPregen = _base.MPregen;
        _improved.HPregen = _base.HPregen;
        this._improved.ChangeSTR(_base.attributes.STR);
        this._improved.ChangeVitality(_base.attributes.vitality);
        this._improved.ChangeIntellect(_base.attributes.intellect);
    }
    public virtual void Start()
    {
        Time.timeScale = 1;
        death = false;
        this.refresh();
        
    }
    // Update is called once per frame
    public virtual void Update()
    {
        if (curHP < _improved.HP && !death)//health regeneration
        {
            curHP += _improved.HPregen * Time.deltaTime;
        }
        if (curHP > _improved.HP)
            curHP = _improved.HP;
        if (curHP <= 0) //≈сли кол-во жизни меньше или равно 0
        {
            curHP = 0; //—тавим 0 дабы наш бар не рисовалс€ не корректно
            death = true; //—тавим что персонаж мертв
        }
        if(curMP<_improved.MP && !death)
        {
            curMP += _improved.MPregen * Time.deltaTime;
        }
        if (curMP < 0)
            curMP = 0;
        if (curMP > _improved.MP)
            curMP = _improved.MP;
        if (curEXP >= ExpToUp) //≈сли количество опыта у нас рано и ли больше нужного кол-ва опыта
        {
            curEXP = ExpToUp; //кол-во опыта ставим 0
        }
    }

    public virtual void lvlUp()
    {
        ++lvl;
        ExpToUp *= 10;
        curEXP = 0;
        ExpForDeath += 50;
    }
    /*public void newImprovedStats()
    {
        int equipmentStats = 0;//вложение от экипировки
        _improved.STR = _base.STR + equipmentStats;
        _improved.vitality = _base.vitality + equipmentStats;
        _improved.energy = _base.energy + equipmentStats;
        _improved.HPregen = _base.HPregen + equipmentStats;
    }*/
    public void refresh()
    {
        curHP = _improved.HP; //¬ начале у персонажа кол-во жизней максимально
        curMP = _improved.MP; //маны тоже
    }
    public float CalculateDamage()
    {
        return _improved.damage.calculate();
    }
    public void getDamage(float  damage)
    {
        curHP -= damage;

    }
    public void GetExpFrom(UnitStats defeatedEnemy)
    {
        this.curEXP += defeatedEnemy.ExpForDeath;
    }
}
