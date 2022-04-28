using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UnitPlayer : HittableEntity
{
    private int pointstat = 0; //���-�� ������� �������� ��� ���������(������ ��� ������)(������� ���� � ���������������� � �������� �����?)
    public bool showStats;
    public UnitPlayer():base(1000,600,20,20,20)
    {
        showStats = false;
        _base.HP = new AbstractStrip(1000,10,100);
  
        StartExistence();
        _improved.damage.minDMG = 30;
        _improved.damage.maxDMG = 40;
    }

    protected  override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.P))
        {
            showStats = !showStats;
        }
        if (exp.isEnouth())
        {
            exp.lvlUp();
            pointstat += 5;
        }
    }

    void OnGUI()
    {
        if (!showStats)
            useGUILayout = false; //�������� ���� ������
        else//�������- ���� ������� GUIskin
        {
            GUI.Box(new Rect(10, 70, 300, 300), "stats");
            GUI.Label(new Rect(10, 95, 300, 300), "LvL: " + exp.level());
            GUI.Label(new Rect(10, 110, 300, 300), "hp: " + _improved.HP.Max());
            GUI.Label(new Rect(10, 125, 300, 300), "mp: " + _improved.MP.Max());
            GUI.Label(new Rect(10, 140, 300, 300), "expToUp: " + exp.RequiredExp());
            GUI.Label(new Rect(10, 155, 300, 300), "str: " + _improved.attributes.STR);
            GUI.Label(new Rect(10, 170, 300, 300), "vitality: " + _improved.attributes.vitality);
            GUI.Label(new Rect(10, 185, 300, 300), "intellect: " + _improved.attributes.intellect);
            GUI.Label(new Rect(10, 200, 300, 300), "damage: " + _improved.damage.minDMG+ " ~ "+ _improved.damage.maxDMG);
            if (pointstat > 0) 
            {
                GUI.Label(new Rect(10, 250, 300, 20), "points " + pointstat.ToString());
                PlusStrButton();
                PlusVitalityButton();
                PlusManIntellectButton();
            }
        }
        if (state == LifeStates.DEAD)
        {
            OnDeadGUI();
        }    
    }

    private void PlusStrButton()
    {
        if (GUI.Button(new Rect(150, 155, 20, 20), "+")) //��� ����
        {
            if (pointstat > 0)
            {
                pointstat -= 1;
                _base.ChangeSTR(1);
                _improved.ChangeSTR(1);
            }
        }
    } 
    private void PlusVitalityButton()
    {
        if (GUI.Button(new Rect(150, 170, 20, 20), "+")) //��� ���������
        {
            if (pointstat > 0)
            {
                pointstat -= 1;
                _base.ChangeVitality(1);
                _improved.ChangeVitality(1);
            }
        }
    }

    private void PlusManIntellectButton()
    {
        if (GUI.Button(new Rect(150, 185, 20, 20), "+")) //��� ����
        {
            if (pointstat > 0)
            {
                pointstat -= 1;
                _base.ChangeIntellect(1);
                _improved.ChangeIntellect(1);
            }
        }
    }

    private void OnDeadGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 100, 50), "����������"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
