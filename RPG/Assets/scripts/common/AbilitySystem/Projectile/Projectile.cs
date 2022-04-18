using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //<пачка булевых переменных определ€юща€ поведение обьекта>
   //может быть и брольше по этмоу тови задумать о вынесении их в отдельный класс  и формироавании шаблона state дл€ класса projectile
    public bool isBase = false;
    public bool createCopiesOnDestroy = false;
    public bool explodeWhenDestory = true;
    bool actionDone = false;
    //</пачка булевых переменных определ€юща€ поведение обьекта>
    public GameObject user;
    public Weapon projectileStats;
    public Cooldown delayBfDestroy = new Cooldown(3.0f);
    public GameObject destroyEffect;
    public float radius = 5.0f;
   
     public void Awake()
    {
        actionDone = false;
        delayBfDestroy.Start—ountdown();
    }
    public void Update()
    {
        if (!isBase)
        {
            if (!delayBfDestroy.IsReady())

            {
                delayBfDestroy.TickTime(Time.deltaTime);
                onFly();
            }
            if (delayBfDestroy.IsReady() && !actionDone)//если таймер уже отсчитал и готов быть уничтожен
            {

                OnEndLiveTime();
                actionDone = true;
            }
        }
    }
    public void OnTouch(GameObject tangentSurface)//что происходит когда снар€д касаетс€ окружени€ или противника
    {
        Debug.Log(gameObject.name + " Touch "+tangentSurface.name);
        OnAttackWhenTouch(tangentSurface);
    }
    public void OnAttackWhenDestroy(GameObject beaten)
    {
        HittableEntity beatenEntity = beaten.GetComponent<HittableEntity>();
        if (beatenEntity != null)
            beatenEntity.HitWillDone(user, projectileStats);

    }
    public void OnAttackWhenTouch(GameObject obj)
    {
        if (obj.tag == "Unit")//в случчае если коснулись юнита
        {
            Debug.Log("encounter a " + obj.name);
            obj.GetComponent<HittableEntity>().Hit(10.0f);//наносиим урон от удара
            //примеры взаимодействий по касанию. надо опписать как можно больше возможных взаимодействий

        }
        //OnEndLiveTime();


    }
    public void OnEndLiveTime()
    {
        if(explodeWhenDestory)
        AttackBehaviour.BlowUp(transform.position, radius, OnAttackWhenDestroy);

        if (createCopiesOnDestroy)
            AttackBehaviour.Create(transform.position, transform.rotation, gameObject, 3);


        
        
        //<base module for projectile>
        if (destroyEffect != null)
        {
            GameObject curEffect = Instantiate(destroyEffect, transform.position, transform.rotation);//запустили эфект который проигрываетс€ при уничтожении обьекта(уничтожить потом его тоже надо)
            Destroy(curEffect, 3.9f);
        }
        //Debug.Log("destroy");
        Destroy(gameObject);
        //</base module for projectile>


    }
    private void onFly()
    {
        
    }
    private void OnCollisionEnter(Collision coll)
    {
        OnTouch(coll.gameObject);
    }
}
