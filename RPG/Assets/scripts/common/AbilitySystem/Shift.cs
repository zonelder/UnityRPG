using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shift
{
    public float initialSpeed;//x=0
    public float finalSpeed;//x=shift.magnitude
    public float intermediateSpeed;//x=intermediateCord
    public float intermediateCord;//between 0 and shift.magnitude
    private float duration;//������������� ��� ����� �� ������� ����� ������� ������ shift � �� ����� ���� ������� �����
    private Vector3 shift;//������ ������� ���� ������

    public Vector3 VectorOfMove(GameObject unit)
    {
        return unit.transform.forward*shift.z +unit.transform.right * shift.x + unit.transform.up * shift.y;
    }

    private float CalculateDuration()
    {
        if (initialSpeed == 0 && intermediateSpeed == 0 && finalSpeed==0)//�� ��������� ������
        {
            shift = Vector3.zero;//���� �� ��� ��� ����� �� ��������� �� � ��� ������ ������� ��������
            return 0;
        }
        if (initialSpeed ==0  && intermediateSpeed==0)//��������� ������ �� ������ ����� ����
        {
            intermediateCord = 0;//������������� ������� ����� �������� ������(���� ���� � ������ �������� ��������-�� �������� �� � ����� �� ������ ����� ��������� ����������)
                return 2 * (intermediateCord / (finalSpeed));
        }
        if( intermediateSpeed==0 && finalSpeed==0)//��������� ������ � ������ ����� ����
        {
            intermediateCord = shift.magnitude;//���� �� ������ �������� �������� �� �������� �� � ����� ������ �������� ��� ������ ���� ����
            return 2 *shift.magnitude / initialSpeed;
        }
        return 2 * ((shift.magnitude - intermediateCord) / (intermediateSpeed + initialSpeed) + intermediateCord / (intermediateSpeed + finalSpeed));//����� �� ������� ����� ������� ���� ���� � ����� �������
    }

}
