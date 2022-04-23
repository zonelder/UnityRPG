using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using stats;
public enum LifeStates
{ 
    STABLE,
    BODY_ON_THE_EDGE,
    MIND_ON_THE_EDGE,
    DEAD
}

public class UnitStats : HittableEntity
{
    public LifeStates state;
    private float bodyAtrophy = 100;//point in second
    private float mindAtrophy = 100;//point in second
    public int lvl = 1;
    public float ExpToUp = 1000;
    public BaseStats _base = new BaseStats(0,0,0,0,0);
    public Stats _improved = new Stats(0, 0, 0, 0, 0);
    public float ExpForDeath;
 
    /// <current value>
    ///
    public float curEXP; //���-�� �����

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
    public void StartExistence()//�������� � �������� ������� � ������������
    {
        //��������� improved;
        _improved.HP=_base.HP;//��� ����� ����� ����� ��������� ������ �������
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
        //death = false;
        state = LifeStates.STABLE;
        this.refresh();
        
    }
    // Update is called once per frame
    public virtual void Update()
    {
        if(state != LifeStates.DEAD)
        {
            if (curHP < _improved.HP)
            {
                curHP += _improved.HPregen * Time.deltaTime;
            }

            if (curMP < _improved.MP)
            {
                curMP += _improved.MPregen * Time.deltaTime;
            }
        }

        if (curHP > _improved.HP)
            curHP = _improved.HP;
        if (curHP <= 0) //���� ���-�� ����� ������ ��� ����� 0
        {
            curHP = 0; //������ 0 ���� ��� ��� �� ��������� �� ���������
            if (state != LifeStates.BODY_ON_THE_EDGE)
            {
                if (state == LifeStates.MIND_ON_THE_EDGE)//���� �� ������������ � ��� ��� � ���� ��������
                    state = LifeStates.DEAD;
                else
                    state = LifeStates.BODY_ON_THE_EDGE;
            }
        }
        if (curMP < 0)
        {
            curMP = 0;
            if(state!=LifeStates.MIND_ON_THE_EDGE)
            {
                if (state == LifeStates.BODY_ON_THE_EDGE)
                    state = LifeStates.DEAD;
                else
                    state= LifeStates.MIND_ON_THE_EDGE;
            }
        }
        if (curMP > _improved.MP)
            curMP = _improved.MP;

        if(state==LifeStates.MIND_ON_THE_EDGE)
        {
            curHP -= bodyAtrophy * Time.deltaTime;
        }
        if(state==LifeStates.BODY_ON_THE_EDGE)
        {
            curMP -= mindAtrophy*Time.deltaTime;
        }
        if (curEXP >= ExpToUp) //���� ���������� ����� � ��� ���� � �� ������ ������� ���-�� �����
        {
            curEXP = ExpToUp; //���-�� ����� ������ 0
        }
    }

    public virtual void lvlUp()
    {
        ++lvl;
        ExpToUp *= 10;
        curEXP = 0;
        ExpForDeath += 50;
    }
    public void refresh()
    {
        curHP = _improved.HP; //� ������ � ��������� ���-�� ������ �����������
        curMP = _improved.MP; //���� ����
    }

    public void GetExpFrom(UnitStats defeatedEnemy)
    {
        this.curEXP += defeatedEnemy.ExpForDeath;
    }
}
