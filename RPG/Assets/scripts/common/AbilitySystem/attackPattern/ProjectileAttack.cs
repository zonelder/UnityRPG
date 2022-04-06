using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : Attack
{
    private bool launchStart = false;
    private float launchTime = 0;//����� ������������ ������ ����� ����� ���� ��������� ������
    private Cooldown launchPreparation;//����� ���������� � ������� �������
    GameObject projectile;
   public ProjectileAttack(GameObject user)
    {

    }

    public override void StartAttack()
    {
        isActive = true;
        //raycat
    }

    public override void TickTime(float delta, float SpeedAmp = 1)
    {
        base.TickTime(delta,SpeedAmp);
        if(property.duration.curTime()>launchTime && !launchStart)
        {
            launchStart = true;
            PrepareForLaunch();
        }
    }
    public void PrepareForLaunch()//���������� � ������� �������(���������� ���� ������������ ��� ������� ������ ��� ����� ������������ ������ )
    {
        //������ ����� ���� ������� � ����� ����� ����� ������ ���� �������
    }
    public void Launch()//��������� ������
    {
        //�������� ������� � ��� 
    }
    public override void EndAttack()
    {
        launchStart = false;
        isActive = false;
    }
}
