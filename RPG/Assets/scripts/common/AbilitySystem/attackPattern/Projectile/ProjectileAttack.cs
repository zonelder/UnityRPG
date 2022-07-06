using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ProjectileState
{
    BEFORE_PREPARATION,
    PREPARATION,
    LAUNCH,
    AFTER_LAUNCH
}

[System.Serializable]
public class ProjectileAttack : Attack
{
    // Пока допустим нормально. хотя свойств уже много, лучше выделить класс под это.
    public Projectile Projectile;

    private ProjectileState pState;
    [SerializeField] private float _launchTime = 0;
    private Cooldown _launchPreparation;

    private Transform _launchPoint;
    public ProjectileAttack(GameObject user)
    {
        _launchPoint = user.transform.Find("weapon").transform;
        _launchPreparation= new Cooldown(1.0f);
    }
    protected sealed override void StartAttack()
    {
        pState = ProjectileState.BEFORE_PREPARATION;
    }

    protected sealed override void TickTime(float delta)
    {
        if (Property.Duration.CurTime() > _launchTime && pState == ProjectileState.BEFORE_PREPARATION )
        {
            pState = ProjectileState.PREPARATION;
            _launchPreparation.StartСountdown();
        }
        if(pState == ProjectileState.PREPARATION && !(_launchPreparation.IsReady))
        {
            RenderTrajectory();
            _launchPreparation.TickTime(delta);
        }

        if(pState == ProjectileState.PREPARATION && _launchPreparation.IsReady)
        {
            
            Launch();
            ClearTrajctory();
            pState = ProjectileState.LAUNCH;
        }

    }
    private void ClearTrajctory()
    {
    }
    private void RenderTrajectory()
    {
        //broken
    }
  
    private void Launch()
    {
        Projectile.Create(_launchPoint, _launchPoint.transform.parent.gameObject.GetComponent<UnitEntity>());
        pState = ProjectileState.AFTER_LAUNCH;
    }
    protected sealed override void EndAttack()
    {
    }
}
