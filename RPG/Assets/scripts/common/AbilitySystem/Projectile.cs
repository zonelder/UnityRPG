using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Cooldown delayBfDestroy = new Cooldown(3.0f);
    public GameObject destroyEffect;
    bool actionDone = false;
     public void Awake()
    {
        delayBfDestroy.StartСountdown();
    }
    public void Update()
    {

        if(!delayBfDestroy.IsReady())
        delayBfDestroy.TickTime(Time.deltaTime);
        if (delayBfDestroy.IsReady() && !actionDone)//если таймер уже отсчитал и готов быть уничтожен
        {

            actionDone = true;
            OnDestroy();
        }
    }
    public void OnTouch()//что происходит когда снаряд касается окружения или противника
    {

    }

    public void OnAttack()//что происходит когда атака снаряда попадает по потивнику
    {

    }

    public void OnDestroy()
    {

        if(destroyEffect!=null)
        {
            Instantiate(destroyEffect, transform.position, transform.rotation);//запустили эфект который проигрывается при уничтожении обьекта
        }


        Debug.Log("destroy");

        Destroy(gameObject);
    }
}
