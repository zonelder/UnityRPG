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
    private RaycastState rState;
    public GameObject HitEffect;
    private Camera Cam;
    private GameObject weapon;
    private LineRenderer laserLine;
    private Cooldown lineRenderTime = new Cooldown(0.4f);
    [SerializeField] private float timeToAim=0.0f;
    [SerializeField] private float timeToShoot=0.4f;
    [SerializeField] private float weaponRange = 100;
    public RaycastAttack(GameObject user)
    {
        weapon = user.transform.Find("weapon").gameObject;
        Cam = user.transform.Find("playerCam").gameObject.GetComponent<Camera>(); ;
        laserLine=weapon.GetComponent<LineRenderer>();
        laserLine.startWidth = 0.02f;
        laserLine.endWidth = 0.02f;

    }
    public override void StartAttack()
    {
        laserLine.positionCount = 2;
        rState = RaycastState.BEFORE_AIMING;
    }
    public override void TickTime(float delta,float SpeedAmp=1)
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
            lineRenderTime.TickTime(Time.deltaTime);
        }
        else
        {
            laserLine.enabled = false;
        }

    }
    private void Aim()
    {
        Vector3 rayOrigin = Cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

        RaycastHit hit;
        Vector3 EndPoint = Vector3.zero;
        laserLine.SetPosition(0, weapon.transform.position);
        if (Physics.Raycast(rayOrigin, Cam.transform.forward, out hit, weaponRange))
        {
            EndPoint = hit.point;
        }
        else
        {
            EndPoint = rayOrigin + (Cam.transform.forward * weaponRange);
        }

        laserLine.SetPosition(1, EndPoint);
        laserLine.enabled = true;
    }
    private void OnAttack(GameObject beaten)
    {
        HittableEntity enemy = beaten.GetComponent<HittableEntity>();
        enemy?.HitWillDone(weapon.transform.parent.gameObject.GetComponent<UnitStats>());
    }
    private void Shoot()
    {

        Vector3 rayOrigin = Cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

        RaycastHit hit;
        Vector3 EndPoint = Vector3.zero;
        laserLine.SetPosition(0, weapon.transform.position);
        if (Physics.Raycast(rayOrigin, Cam.transform.forward, out hit, weaponRange))
        {
            EndPoint = hit.point;
        }
        else
        {
            EndPoint = rayOrigin + (Cam.transform.forward * weaponRange);
        }

        laserLine.SetPosition(1, EndPoint);
        laserLine.enabled = true;

        //OnHit.Execute();
        AttackBehaviour.BlowUp(EndPoint, 5, OnAttack);

        if (HitEffect != null)
        {
            GameObject curEffect = MonoBehaviour.Instantiate(HitEffect, laserLine.GetPosition(1), Cam.transform.rotation);//запустили эфект который проигрывается при уничтожении обьекта(уничтожить потом его тоже надо)
            MonoBehaviour.Destroy(curEffect, 3.9f);
        }

        rState = RaycastState.AFTER_SHOOT;
    }
    public override void EndAttack()
    {
        laserLine.positionCount = 0;
    }
   
}
