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


    public void DamageInBlockDone()
    {
        if (recovery.IsReady())//���� ���� ��� ������� ������� �� ��������� �����  �� ��������� ������
            recovery.Start�ountdown();
        else//���� ���� ��� ��������� �� ��������� ������
            recovery.RestartCountdown();
    }
}
