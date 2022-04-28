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

public class ProjectileAttack : Attack//пока допустим нормально. хотя свойств уже много, лучше выделить класс под это
{
    private ProjectileState pState;
    private LineRenderer sightLine;
    private float impulseLaunch = 10.0f;
    private float launchTime = 0;//время относительно начала атаки когда надо запустить снаряд
    private Cooldown launchPreparation;//время подготовки с запуску снаряда
    private GameObject projectile;
    private GameObject weapon;
    private GameObject camera;
   public ProjectileAttack(GameObject user)
    {
        weapon = user.transform.Find("weapon").gameObject;
        camera = user.transform.Find("playerCam").gameObject;
        launchPreparation= new Cooldown(1.0f);
        sightLine = weapon.GetComponent<LineRenderer>();
    }
    public void SetProjectile(GameObject newProjectile)//плохой очень метод
    {
        projectile = newProjectile;
        projectile.GetComponent<Projectile>().isBase = true;
        projectile.GetComponent<Projectile>().projectileStats = weapon.GetComponent<Weapon>();
        projectile.GetComponent<Projectile>().user = weapon.transform.parent.gameObject;
    }
 
    public override void StartAttack()
    {
        base.StartAttack();
        pState = ProjectileState.BEFORE_PREPARATION;
    }

    public override void TickTime(float delta, float SpeedAmp = 1)
    {
        base.TickTime(delta,SpeedAmp);
        if (property.duration.curTime() > launchTime && pState == ProjectileState.BEFORE_PREPARATION )
        {
            pState = ProjectileState.PREPARATION;
            launchPreparation.StartСountdown();
        }
        if(pState == ProjectileState.PREPARATION && !(launchPreparation.IsReady()))
        {
            RenderTrajectory();
            launchPreparation.TickTime(delta);
        }

        if(pState == ProjectileState.PREPARATION && launchPreparation.IsReady())
        {
            
            Launch();
            ClearTrajctory();
            pState = ProjectileState.LAUNCH;
        }

    }
    private void ClearTrajctory()
    {
        sightLine.positionCount = 0;
        sightLine.enabled = false;
    }
    private void RenderTrajectory()
    {
        sightLine.enabled = true;
        Collider _hitObject = null;
        const int segmentCount = 20;

        Vector3[] segments = new Vector3[segmentCount];


        // The first line point is wherever the player's cannon, etc is
        segments[0] = weapon.transform.position + weapon.transform.forward;
        float segmentScale = 1;

        Vector3 segVelocity = camera.transform.forward * impulseLaunch / projectile.GetComponent<Rigidbody>().mass;
        for (int i=1;i<segmentCount;i++)
        {
            float segTime = (segVelocity.sqrMagnitude != 0) ? segmentScale / segVelocity.magnitude : 0;

            segVelocity = segVelocity + Physics.gravity * segTime;

            RaycastHit hit;

            if (Physics.Raycast(segments[i - 1], segVelocity, out hit, segmentScale))
            {

                _hitObject = hit.collider;

                segments[i] = segments[i - 1] + segVelocity.normalized * hit.distance;

                segVelocity = segVelocity - Physics.gravity * (segmentScale - hit.distance) / segVelocity.magnitude;
                //bounce
                
                
                //incorect in some cases.is should be calculate using physicMaterials;
                segVelocity = Vector3.Reflect(segVelocity, hit.normal);
            }
            // If our raycast hit no objects, then set the next position to the last one plus v*t
            else
            {
                segments[i] = segments[i - 1] + segVelocity * segTime;
            }

        }
        Color startColor = Color.red;
        Color endColor = startColor;
        startColor.a = 1;
        endColor.a = 0;
        sightLine.endColor = Color.red;
        sightLine.startColor = Color.red;

        sightLine.positionCount= segmentCount;
        for (int i = 0; i < segmentCount; i++)
            sightLine.SetPosition(i, segments[i]);
    }
  
    private void Launch()//запускаем снаряд
    {
        //создание снаряда и его запуск
        GameObject curProjectile= MonoBehaviour.Instantiate(projectile, weapon.transform.position + weapon.transform.forward, weapon.transform.rotation);
        curProjectile.GetComponent<Projectile>().isBase = false;
        curProjectile.GetComponent<Rigidbody>().AddForce(impulseLaunch*camera.transform.forward,ForceMode.Impulse);

        pState = ProjectileState.AFTER_LAUNCH;
    }
    public override void EndAttack()
    {
        base.EndAttack();
    }
}
