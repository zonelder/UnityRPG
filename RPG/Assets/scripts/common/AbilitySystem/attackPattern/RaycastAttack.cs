using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastAttack : Attack
{
    private bool shootDone=false;
    public GameObject HitEffect;
    private GameObject Cam;
    public GameObject weapon;
    private LineRenderer laserLine;
    private Cooldown lineRenderTime = new Cooldown(0.4f);
    public float timeToShoot=0;
    public float weaponRange = 100;
    public RaycastAttack(GameObject user)
    {
        weapon = user.transform.Find("weapon").gameObject;
        Cam = user.transform.Find("playerCam").gameObject;
        laserLine=weapon.GetComponent<LineRenderer>();
        laserLine.startWidth = 0.02f;
        laserLine.endWidth = 0.02f;

    }
    public override void StartAttack()
    {
        isActive = true;
        laserLine.positionCount = 2;
        //raycat
    }
    public override void TickTime(float delta,float SpeedAmp=1)
    {
        base.TickTime(delta,SpeedAmp);
        if(property.duration.curTime() >timeToShoot && !shootDone)
        {
            shootDone = true;
            Shoot();
        }
        if (!lineRenderTime.IsReady())
        {
            lineRenderTime.TickTime(Time.deltaTime);
        }
        else
        {
            laserLine.enabled = false;
        }

    }
    public void OnAttack(GameObject beaten)
    {
        HittableEntity enemy = beaten.GetComponent<HittableEntity>();
        if (enemy!=null)
        enemy.HitWillDone(weapon.transform.parent.gameObject, weapon.GetComponent<Weapon>());
    }
    public void Shoot()
    {
        // Create a vector at the center of our camera's viewport
        Vector3 rayOrigin = Cam.GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

        RaycastHit hit;
        Vector3 EndPoint = Vector3.zero;
        laserLine.SetPosition(0, weapon.transform.position);
        if (Physics.Raycast(rayOrigin, Cam.GetComponent<Camera>().transform.forward, out hit, weaponRange))
        {
            EndPoint = hit.point;
        }
        else
        {
            EndPoint = rayOrigin + (Cam.transform.forward * weaponRange);
        }

        AttackBehaviour.BlowUp(EndPoint, 5, OnAttack);
        //<base module for raycast>
            //<lazerRender>
        laserLine.SetPosition(1, EndPoint);
        lineRenderTime.StartСountdown();
        laserLine.enabled = true;
            //</lazerRender>
        if (HitEffect != null)
        {
            GameObject curEffect = MonoBehaviour.Instantiate(HitEffect, laserLine.GetPosition(1), Cam.transform.rotation);//запустили эфект который проигрывается при уничтожении обьекта(уничтожить потом его тоже надо)
            MonoBehaviour.Destroy(curEffect, 3.9f);
        }
        //</base module for raycast>
    }
    public override void EndAttack()
    {
        shootDone = false;
        isActive = false;
        laserLine.positionCount = 0;
    }
   
}
