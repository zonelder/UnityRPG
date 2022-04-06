using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : Attack
{
    private bool launchStart = false;
    private float launchTime = 0;//время относительно начала атаки когда надо запустить снаряд
    private Cooldown launchPreparation;//время подготовки с запуску снаряда
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
    public void PrepareForLaunch()//подготовка к запуску снаряда(появляется трек показывающий как полетит снаряд при таком расположении камеры )
    {
        //снаряд может быть вупущен в любое время после начала этой функции
    }
    public void Launch()//запускаем снаряд
    {
        //создание снаряда и его 
    }
    public override void EndAttack()
    {
        launchStart = false;
        isActive = false;
    }
}
