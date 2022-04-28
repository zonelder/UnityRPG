using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : Strip
{
    //����� ����� ����� � ����� -���� ���� ������ �� � ����� �� ��� �� � � ����.
    //����� ���� ������������ ������ ������ ��� ����-�� ����� ������ ��� �������� ������������� �����
    //������� ����� ������ ���������� ����� ������ ����������� ������ ������������ ���( �� ������ �� ������� ����)

    private Cooldown recovery;//������ �� ����� ��������� ����� � ���� �� ������ ��� �������������



    public Block(float _max) : base(_max) { }

    public Block(float _max, float reg, float atrophy = 0) : base(_max, reg, atrophy) { }


    public override void StripTick(float deltaTime, LifeStates state)
    {
        if (recovery.IsReady())
        {
            current += regen * deltaTime;
            if (current > max)
                current = max;

        }
        else
            recovery.TickTime(deltaTime);

        if (current <= 0)
            current = 0;
        if (state == AtrophyActivatorState)
        {
            current -= atrophy * deltaTime;
        }
    }

    public void DamageInBlockDone()
    {
        if (recovery.IsReady())//���� ���� ��� ������� ������� �� ��������� �����  �� ��������� ������
            recovery.Start�ountdown();
        else//���� ���� ��� ��������� �� ��������� ������
            recovery.RestartCountdown();
    }
}
