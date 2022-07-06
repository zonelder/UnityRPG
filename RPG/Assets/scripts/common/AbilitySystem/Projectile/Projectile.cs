using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public IDestroyable DestroyBehaviour;
    public ITouchable TouchBehavoiur;
    public IMoveable MoveBehaviour;
    public Cooldown DelayBfDestroy = new Cooldown(3.0f);

    private UnitEntity _user;
    public  void Create(Transform createPoint,UnitEntity user)
    {
        GameObject curProjectile = MonoBehaviour.Instantiate(gameObject, createPoint.position, createPoint.rotation);

        curProjectile.GetComponent<Projectile>().DestroyBehaviour =DestroyBehaviour;
        curProjectile.GetComponent<Projectile>().TouchBehavoiur = TouchBehavoiur;
        curProjectile.GetComponent<Projectile>().MoveBehaviour = MoveBehaviour;

        curProjectile.GetComponent<Projectile>().SetUser(user);
    }
    public void SetUser(UnitEntity user)
    {
        _user = user;
    }
    public void Start()
    {
        DelayBfDestroy.StartСountdown();
        MoveBehaviour.Execute(this,transform, _user);
    }
    public void Update()
    {
        if (!DelayBfDestroy.IsReady)
        {
            DelayBfDestroy.TickTime(Time.deltaTime);
        }
        if (DelayBfDestroy.IsReady)
        {
            // если таймер уже отсчитал и  обьект готов быть уничтожен
            EndLiveTime();
        }
    } 
    private void EndLiveTime()
    {
        DestroyBehaviour?.Execute(transform.position, _user);
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision coll)
    {
        TouchBehavoiur.Execute(coll.gameObject, _user);
    }
}
