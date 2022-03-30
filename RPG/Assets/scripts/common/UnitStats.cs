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
    public float curHP; //���-�� ������ �������� ��������
    public float curMP; //���-�� ���� ���������
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
        if (curHP <= 0) //���� ���-�� ����� ������ ��� ����� 0
        {
            curHP = 0; //������ 0 ���� ��� ��� �� ��������� �� ���������
            death = true; //������ ��� �������� �����
        }
        if(curMP<_improved.MP && !death)
        {
            curMP += _improved.MPregen * Time.deltaTime;
        }
        if (curMP < 0)
            curMP = 0;
        if (curMP > _improved.MP)
            curMP = _improved.MP;
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
    /*public void newImprovedStats()
    {
        int equipmentStats = 0;//�������� �� ����������
        _improved.STR = _base.STR + equipmentStats;
        _improved.vitality = _base.vitality + equipmentStats;
        _improved.energy = _base.energy + equipmentStats;
        _improved.HPregen = _base.HPregen + equipmentStats;
    }*/
    public void refresh()
    {
        curHP = _improved.HP; //� ������ � ��������� ���-�� ������ �����������
        curMP = _improved.MP; //���� ����
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
