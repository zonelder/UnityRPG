using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDummy : UnitNIP
{
    // Start is called before the first frame update
    
    public UnitDummy():base(700, 0, 0, 0, 0)//�������� �� ������� �������������� � ������� �����
    {
        // _base.HP = 700;
        // _base.MP = 0; 
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
        if (curHP <= 0) //���� ���-�� ����� ������ ��� ����� 0
        {
            Debug.Log("dummy has been killed");
            death = false;
            curHP = _improved.HP; //������ 0 ���� ��� ��� �� ��������� �� ���������
            //death = true; //������ ��� �������� �����
        }
    }
}
