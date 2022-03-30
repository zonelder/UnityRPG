using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractAbility : ScriptableObject//������ ��� �� ���� ����� ���������������� ��������� � ���������� ��������� �������
{
    public string name;
    public bool isActive = false;

    protected AbstractAbility(string name)
    {
        this.name = name;
    }
    protected AbstractAbility()
    {

    }
    public abstract void StartAbility();
    public abstract void EndAbility();




    public abstract bool IsActiveAbility();
    public abstract bool IsPassiveAbility();

}
