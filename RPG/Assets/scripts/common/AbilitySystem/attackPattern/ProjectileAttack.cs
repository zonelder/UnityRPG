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
    private ProjectileState pState;
    [SerializeField] private float _launchTime = 0;
    private Cooldown _launchPreparation;
    [SerializeField] private GameObject _projectile;
    private Transform _launchPoint;
    private GameObject _camera;
   public ProjectileAttack(GameObject user)
    {
        _launchPoint = user.transform.Find("weapon").transform;
        _camera = user.transform.Find("playerCam").gameObject;
        _launchPreparation= new Cooldown(1.0f);
    }
    public void SetProjectile(GameObject newProjectile)//плохой очень метод
    {
        _projectile = newProjectile;
        _projectile.GetComponent<Projectile>().isBase = true;
        _projectile.GetComponent<Projectile>().User = _launchPoint.transform.parent.gameObject.GetComponent<UnitStats>();
       
    }
 
    public override void StartAttack()
    {
        pState = ProjectileState.BEFORE_PREPARATION;
    }

    public override void TickTime(float delta, float SpeedAmp = 1)
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
        GameObject curProjectile= MonoBehaviour.Instantiate(_projectile, _launchPoint.position + _launchPoint.forward, _launchPoint.transform.rotation);
        curProjectile.GetComponent<Projectile>().SettingTrajectory(_launchPoint);
        curProjectile.GetComponent<Projectile>().isBase = false;

        pState = ProjectileState.AFTER_LAUNCH;
    }
    public override void EndAttack()
    {
    }
}
