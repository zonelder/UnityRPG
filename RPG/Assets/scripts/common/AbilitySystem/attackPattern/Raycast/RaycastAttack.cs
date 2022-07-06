using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RaycastState
{
    BEFORE_AIMING,
    AIMING,
    SHOOT,
    AFTER_SHOOT
}

[System.Serializable]
public class RaycastAttack : Attack
{
    public IHit ShootBehaviour;
    // может все же стоит обьединить( так на пример баллистическое поведение будет кончатьс там где упал снаряд(а если не упадет?))
    public IAim AimBehaviour;
    [SerializeField] private float weaponRange = 100;

    private RaycastState rState;
    private Camera _camera;
    private Transform _weaponTransform;
    [SerializeField] private LineRenderer laserLine;
    private Cooldown lineRenderTime = new Cooldown(0.4f);
    [SerializeField] private float timeToAim=0.0f;
    [SerializeField] private float timeToShoot=0.4f;

    public RaycastAttack(GameObject user)
    {
        _weaponTransform = user.transform.Find("weapon").transform;
        _camera = user.transform.Find("playerCam").gameObject.GetComponent<Camera>(); ;
        laserLine= _weaponTransform.GetComponent<LineRenderer>();
        laserLine.startWidth = 0.02f;
        laserLine.endWidth = 0.02f;
    }
    protected sealed override void StartAttack()
    {
        laserLine.positionCount = 2;
        rState = RaycastState.BEFORE_AIMING;
    }
    protected sealed override void TickTime(float delta)
    {
        if(Property.Duration.CurTime()>timeToAim && rState==RaycastState.BEFORE_AIMING)
        {
            rState = RaycastState.AIMING;
            lineRenderTime.StartСountdown();
        }
        if(rState ==RaycastState.AIMING && !(Property.Duration.CurTime() > timeToShoot))
        {
            Aim();

        }
        if(rState == RaycastState.AIMING && Property.Duration.CurTime() > timeToShoot)
        {
            rState = RaycastState.SHOOT;
            Shoot();
        }
        if (!lineRenderTime.IsReady)
        {
            lineRenderTime.TickTime(delta);
        }
        else
        {
            laserLine.enabled = false;
        }

    }
    private void Aim()
    {
        Vector3? hitPoint = AimBehaviour?.Execute(_camera, weaponRange);
        if(hitPoint.HasValue)
        {
            // Локику отображений целесообразно тоже куда то убрать(где то надо метить область где-то показывать трек)
            laserLine.positionCount = 2;
            laserLine.SetPosition(0, _weaponTransform.position);
            laserLine.SetPosition(1, hitPoint.Value);
            laserLine.enabled = true;
        }
    }
    private void Shoot()
    {
        Vector3? hitPoint = AimBehaviour?.Execute(_camera, weaponRange);

        if(hitPoint.HasValue)
        ShootBehaviour?.Execute(hitPoint.Value, _weaponTransform.parent.gameObject.GetComponent<UnitEntity>());

        rState = RaycastState.AFTER_SHOOT;
    }
    protected sealed override void EndAttack()
    {
        laserLine.positionCount = 0;
    }
   
}
