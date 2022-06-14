using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // <пачка булевых переменных определяющая поведение обьекта>
   // может быть и больше поэтому cтоиn задумать о вынесении их в отдельный класс(шаблон state machine)
    [SerializeField] public  bool isBase = false;//надо зактырть
    [SerializeField] private bool createCopiesOnDestroy = false;
    [SerializeField] private bool explodeWhenDestory = true;
    private bool actionDone = false;
    //</пачка булевых переменных определяющая поведение обьекта>

    public UnitStats User;//надо закрыть
    private Cooldown delayBfDestroy = new Cooldown(3.0f);
    [SerializeField] private GameObject destroyEffect;
    [SerializeField] private Shift _moveTrajectory;
    private float radius = 5.0f;
   
     public void Awake()
    {
        actionDone = false;
        delayBfDestroy.StartСountdown();
    }
    public void SettingTrajectory(Transform unitTransform)
    {
        // broken
        _moveTrajectory.Duration.SetCooldown(delayBfDestroy.GetCooldown());
        _moveTrajectory.Duration.StartСountdown();
        _moveTrajectory.SetStartTransform(unitTransform);
    }
    public void Update()
    {
        if (!isBase)
        {
            if (!delayBfDestroy.IsReady)
            {
                delayBfDestroy.TickTime(Time.deltaTime);
                onFly();
            }
            if (delayBfDestroy.IsReady && !actionDone)
            {
                // если таймер уже отсчитал и готов быть уничтожен
                OnEndLiveTime();
                actionDone = true;
            }
        }
    }
    public void OnTouch(GameObject tangentSurface)
    {
        Debug.Log(gameObject.name + " Touch "+tangentSurface.name);
        OnAttackWhenTouch(tangentSurface);
    }
    public void OnAttackWhenDestroy(GameObject beaten)
    {
        HittableEntity beatenEntity = beaten.GetComponent<HittableEntity>();
        beatenEntity?.HitWillDone(User);

    }
    public void OnAttackWhenTouch(GameObject obj)
    {
        HittableEntity beatenEntity = obj.GetComponent<HittableEntity>();
        beatenEntity?.HitWillDone(User);
    }
    public void OnEndLiveTime()
    {
        if(explodeWhenDestory)
            AttackBehaviour.BlowUp(transform.position, radius, OnAttackWhenDestroy);

        if (createCopiesOnDestroy)
            AttackBehaviour.Create(transform.position, transform.rotation, gameObject, 3);
        // <base module for projectile>
        if (destroyEffect != null)
        {
            // запустили эфект который проигрывается при уничтожении обьекта(уничтожить потом его тоже надо)

            GameObject curEffect = Instantiate(destroyEffect, transform.position, transform.rotation);
            Destroy(curEffect, 3.9f);
        }
        Destroy(gameObject);
        // </base module for projectile>
    }
    private void onFly()
    {
        _moveTrajectory.Duration.TickTime(Time.deltaTime);
        transform.position = _moveTrajectory.CurPosition();
    }
    private void OnCollisionEnter(Collision coll)
    {
        OnTouch(coll.gameObject);
    }

    public GameObject GetDestroyEffect() => destroyEffect;
    public void StopCopy() => createCopiesOnDestroy = false;
    public void SwitchBase() => isBase = !isBase;

}
