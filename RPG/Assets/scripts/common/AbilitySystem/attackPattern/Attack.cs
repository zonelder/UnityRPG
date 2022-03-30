using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : ScriptableObject
{
   
    protected bool isActive=false; 
    //<���������� ���������� �� ������������ �����������> 
    protected bool isGrab = false;//�������������� �� ������ ��� ������������� �����������(� ������� ����������� ����������� ��������� � �� ����������� �������� ���������� ��� ��������� ��� ����� rigitBody)
    //private bool canMove=false; 
    //</���������� ���������� �� ������������ �����������>
    protected Animation attackAnimation;
    /// <����������_����������_��_��������������>
    public AttackStats property=new AttackStats();
    /// </����������_����������_��_��������������>
    //public List<TimedBuff> buffOnUser;
    //public List<TimedBuff> buffOnTarget;
    public bool InUse() { return isActive; }
    public virtual  void StartAttack()
    {
        
        isActive = true;
        //attackAnimation["attack"].speed=property.GetSpeed();
        //attackAnimation.Play("attack");
        //while (attackAnimation.isPlaying) { continue; };

        //EndAttack();
    }

    public virtual void EndAttack()
    {
        //Debug.Log("end");
        //attackAnimation.Stop();
        isActive = false;
    }
}
