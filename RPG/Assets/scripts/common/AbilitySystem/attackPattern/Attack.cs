using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : ScriptableObject
{
   
    protected bool isActive=false; 
    //<переменные отвечающие за качественные особенности> 
    protected bool isGrab = false;//производитьься ли захват при использовании способности(у таргера блокируется возможность двигаться и он подчиняется анимации заложенной тут становясь как амеда rigitBody)
    //private bool canMove=false; 
    //</переменные отвечающие за качественные особенности>
    protected Animation attackAnimation;
    /// <переменные_отвечающие_за_характеристики>
    public AttackStats property=new AttackStats();
    /// </переменные_отвечающие_за_характеристики>
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
