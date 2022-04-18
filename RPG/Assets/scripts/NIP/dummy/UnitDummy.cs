using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDummy : UnitNIP
{
    // Start is called before the first frame update
    public bool reviveAtOnce = true;
    public UnitDummy():base(700, 200, 0, 0, 0)//�������� �� ������� �������������� � ������� �����
    {
        // _base.HP = 700;
         //_base.MP = 200; 
        // _base.STR = 0;
        //  _base.vitality = 0;
        //  _base.energy = 0
        base.ExpForDeath = 200;//�� �������� ���� ������� � start
        this.StartExistence();

    }
    public override void lvlUp()//����������� ��������� ����� ��������� ��������� �� ����� �������
    {
        curEXP = 0;
    }
    public override void Start()
    {
        base.Start();
        base.ExpForDeath = 200;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (state== LifeStates.DEAD) //���� ���-�� ����� ������ ��� ����� 0
        {
            Debug.Log("dummy has been killed");
            //state = LifeStates.DEAD;
            //death = false;
            if(reviveAtOnce)
            {
                state = LifeStates.STABLE;
                curHP = _improved.HP; //������ 0 ���� ��� ��� �� ��������� �� ���������
                                      //death = true; //������ ��� �������� �����
                curMP = _improved.MP;
            }

        }
    }
}
