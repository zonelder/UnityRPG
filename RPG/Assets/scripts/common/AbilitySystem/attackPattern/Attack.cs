using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack
{
   
    protected bool isActive=false; 
    //<���������� ���������� �� ������������ �����������> 
    protected bool isGrab = false;//�������������� �� ������ ��� ������������� �����������(� ������� ����������� ����������� ��������� � �� ����������� �������� ���������� ��� ��������� ��� ����� rigitBody)
    //private bool canMove=false; 
    //</���������� ���������� �� ������������ �����������>
    protected Animation attackAnimation;
    /// <����������_����������_��_��������������>
    public AttackStats property=new AttackStats();
    public Shift shift=new Shift();
    /// </����������_����������_��_��������������>
    //public List<TimedBuff> buffOnUser;
    //public List<TimedBuff> buffOnTarget;
    public bool InUse() { return isActive; }
    public virtual  void StartAttack()
    {
        
        isActive = true;
        property.duration.Start�ountdown();
        //attackAnimation["attack"].speed=property.GetSpeed();
        //attackAnimation.Play("attack");
        //while (attackAnimation.isPlaying) { continue; };

        //EndAttack();
    }

    public virtual void TickTime(float delta,float finalSpeedAmp=1)
    {
        property.duration.TickTime(delta);
        if(!shift.alreadyUsed && property.duration.curTime()>shift.startTime)// � ������ ����  ��� �� ������ ����������� �� �������� ���������� 
        {
            shift.duration.Start�ountdown();
            shift.alreadyUsed = true;
        }
        if(!shift.duration.IsReady())
        {
            shift.duration.TickTime(finalSpeedAmp*delta);
        }
    }
    /*��������� ������ �� �������- ���� ����� ������ OnMove on Attack OnUse etc. �� ����� ���������� ��� ��������� ����� ����������. �� ��������� ��� ����� �������� ������ �� ������?
    public void OnMove(Vector3 move)
    {
        move *= property.GetSpeedAmp();
    }
    */
    public void CalculateDuration()
    {
        float shiftEndTime = shift.duration.GetCooldown() + shift.startTime;
        if (shiftEndTime > property.duration.GetCooldown())//���� ������ ����������� ������ ��� ���
        {
            float dt = shiftEndTime - property.duration.GetCooldown();
            property.duration.SetCooldown(property.duration.GetCooldown() + dt);//����������� ����� ����� ����� ������� � ���� � ����� ����
        }
       
    }
    public virtual void EndAttack()
    {
        //Debug.Log("end");
        //attackAnimation.Stop();
        isActive = false;
        shift.alreadyUsed = false;
    }
}
