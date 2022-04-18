using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UnitPlayer : UnitStats
{
    int pointstat = 0; //���-�� ������� �������� ��� ���������(������ ��� ������)
    public bool showStats;
    public UnitPlayer():base(1000,600,20,20,20)
    {
        //����������
       // _base.HP = 1000;
       // _base.MP = 600;
       // _base.STR = 20;
        //_base.vitality = 20;
        //_base.energy = 20;
        _improved.damage.minDMG = 30;
        _improved.damage.maxDMG = 40;
        _improved.HPregen = 10;
        //this.newImprovedStats();
        //this.newDmg();
        showStats = false;
        StartExistence();
    }

   public override  void Start()
    {
        base.Start();
        curHP = _improved.HP / 2;
    }


    // Update is called once per frame
    public override void Update()
    {
        base.Update();
            if (Input.GetKeyDown(KeyCode.P)) //���������� �� ������� P
            {
            //GetComponent<PlayerGUI>().showStats = !GetComponent<PlayerGUI>().showStats;//������ ��������� ��� ��������� ����(����� ��������� ���� ���� � ������)
            showStats = !showStats;
            }

        if (curEXP >=ExpToUp) //���� ���������� ����� � ��� ���� � �� ������ ������� ���-�� �����
        {
            this.lvlUp(); //�������� �������
            pointstat += 5; //��������� ���� ������
        }
    }

    void OnGUI()
    {
        if (showStats)
        {
            GUI.Box(new Rect(10, 70, 300, 300), "stats");
            GUI.Label(new Rect(10, 95, 300, 300), "LvL: " + lvl);
            GUI.Label(new Rect(10, 110, 300, 300), "hp: " + _improved.HP);
            GUI.Label(new Rect(10, 125, 300, 300), "mp: " + _improved.MP);
            GUI.Label(new Rect(10, 140, 300, 300), "exp: " + ExpToUp);
            GUI.Label(new Rect(10, 155, 300, 300), "str: " + _improved.attributes.STR);
            GUI.Label(new Rect(10, 170, 300, 300), "vitality: " + _improved.attributes.vitality);
            GUI.Label(new Rect(10, 185, 300, 300), "intellect: " + _improved.attributes.intellect);
            GUI.Label(new Rect(10, 200, 300, 300), "damage: " + _improved.damage.minDMG+ " ~ "+ _improved.damage.maxDMG);
            if (pointstat > 0) //���� ����� ������ ������ 0 ������ ������ ��� ��������� ������
            {
                GUI.Label(new Rect(10, 250, 300, 20), "points " + pointstat.ToString());
                if (GUI.Button(new Rect(150, 155, 20, 20), "+")) //��� ����
                {
                    if (pointstat > 0)
                    {
                        pointstat -= 1;
                        _base.ChangeSTR(1);
                        _improved.ChangeSTR(1);
                    }
                }
                if (GUI.Button(new Rect(150, 170, 20, 20), "+")) //��� ���������
                {
                    if (pointstat > 0)
                    {
                        pointstat -= 1;
                        _base.ChangeVitality(1);
                        _improved.ChangeVitality(1);
                    }
                }
                if (GUI.Button(new Rect(150, 185, 20, 20), "+")) //��� ����
                {
                    if (pointstat > 0)
                    {
                        pointstat -= 1;
                        //_base.energy += 1;
                        _base.ChangeIntellect(1);
                        _improved.ChangeIntellect(1);
                    }
                }
            }
        }
        else// if (showstat == 0)
            useGUILayout = false; //�������� ���� ������
        if (base.death == true) //���� ������
        {
            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 100, 50), "����������")) //������ ������ ����������
            {
               SceneManager.LoadScene(0);
            }
        }

        
    }
}
