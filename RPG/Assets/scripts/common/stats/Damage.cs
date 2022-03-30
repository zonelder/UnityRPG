using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage
{
    public float minDMG=0; //����������� ��������� ����(������������� �� �������)
    public float maxDMG=0; //������������ ��������� ���� (������������� �� �������)
    public float critChan�e = 30.0f;// �������� ����� 0 � 100;
    public float critDamage = 1.5f;//�������� ������ ������ (���� critDamage=1.5 � ������� �� 100 ����� �� ��� ����� ����� 150)
    public void  ChangeDamage(float d_min,float d_max)
    {
        minDMG += d_min;
        maxDMG += d_max;
    }
    public float calculate()//������� ��� ��� ����� ��������� ��� �� ���� � ������ ��������� �����
    {
        float curDamage = 0;

        curDamage = Random.Range(minDMG, maxDMG);//���������� ��������� ����� �� minDMG �� maxDMG
        if (Random.Range(0.0f, 100.0f) <= critChan�e)//���� ������ ����
        {
            curDamage *= critDamage;
        }
        return curDamage;
    }

}
