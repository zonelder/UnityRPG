using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack
{
   
    protected bool isActive=false; 
    //<переменные отвечающие за качественные особенности> 
    protected bool isGrab = false;//производитьься ли захват при использовании способности(у таргера блокируется возможность двигаться и он подчиняется анимации заложенной тут становясь как амеда rigitBody)
    //private bool canMove=false; 
    //</переменные отвечающие за качественные особенности>
    protected Animation attackAnimation;
    /// <переменные_отвечающие_за_характеристики>
    public AttackStats property=new AttackStats();
    public Shift shift=new Shift();
    /// </переменные_отвечающие_за_характеристики>
    //public List<TimedBuff> buffOnUser;
    //public List<TimedBuff> buffOnTarget;
    public bool InUse() { return isActive; }
    public virtual  void StartAttack()
    {
        
        isActive = true;
        property.duration.StartСountdown();
        //attackAnimation["attack"].speed=property.GetSpeed();
        //attackAnimation.Play("attack");
        //while (attackAnimation.isPlaying) { continue; };

        //EndAttack();
    }

    public virtual void TickTime(float delta,float finalSpeedAmp=1)
    {
        property.duration.TickTime(delta);
        if(!shift.alreadyUsed && property.duration.curTime()>shift.startTime)// в случае если  еще не юзалос перемещение то начинаем перемещать 
        {
            shift.duration.StartСountdown();
            shift.alreadyUsed = true;
        }
        if(!shift.duration.IsReady())
        {
            shift.duration.TickTime(finalSpeedAmp*delta);
        }
    }
    /*возможный шаблон на будущее- если везде пихать OnMove on Attack OnUse etc. то можно перебирать все возможные точки активности. но насколько это лучше хранения общего их вклада?
    public void OnMove(Vector3 move)
    {
        move *= property.GetSpeedAmp();
    }
    */
    public void CalculateDuration()
    {
        float shiftEndTime = shift.duration.GetCooldown() + shift.startTime;
        if (shiftEndTime > property.duration.GetCooldown())//если абилка закоччиться раньше чем дэш
        {
            float dt = shiftEndTime - property.duration.GetCooldown();
            property.duration.SetCooldown(property.duration.GetCooldown() + dt);//увеличиваем время чтобы атака кончала в упор к концу деша
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
