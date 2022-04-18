using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : Attack//пока допустим нормально. хотя свойств уже много, лучше выделить класс под это
{
    private LineRenderer sightLine;
    private bool launchStart = false;
    private bool preparationStart = false;
    private float impulseLaunch = 10.0f;
    private float launchTime = 0;//время относительно начала атаки когда надо запустить снаряд
    private Cooldown launchPreparation;//время подготовки с запуску снаряда
    private GameObject projectile;//участвует в любом случает-мы должны знать что кидаем
    private GameObject weapon;// участие посредственное.используется только часть функционала
    private GameObject camera;// участвует в любом случае- мы должны знать куда кидаем
   public ProjectileAttack(GameObject user)
    {
        weapon = user.transform.Find("weapon").gameObject;//пусть пока так
        camera = user.transform.Find("playerCam").gameObject;
        launchPreparation= new Cooldown(1.0f);//одну секунду можем готовиться
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
        isActive = true;
    }

    public override void TickTime(float delta, float SpeedAmp = 1)
    {
        base.TickTime(delta,SpeedAmp);
        if(property.duration.curTime()>launchTime && !launchStart)
        {
            //launchStart = true;
            if(!preparationStart)
            PrepareForLaunch();
            else
            {
                launchPreparation.TickTime(Time.deltaTime);
                RenderTrajectory();
            }
        }
        if (preparationStart && launchPreparation.IsReady() && !launchStart)
        {
            launchStart = true;
            Launch();
            ClearTrajctory();
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
        //Debug.Log("render trajectory");

        Vector3[] segments = new Vector3[segmentCount];
        // The first line point is wherever the player's cannon, etc is
        segments[0] = weapon.transform.position + weapon.transform.forward;
        float segmentScale = 1;

        Vector3 segVelocity = camera.transform.forward * impulseLaunch / projectile.GetComponent<Rigidbody>().mass;// * Time.deltaTime;
        for (int i=1;i<segmentCount;i++)
        {
            float segTime = (segVelocity.sqrMagnitude != 0) ? segmentScale / segVelocity.magnitude : 0;

            // Add velocity from gravity for this segment's timestep
            segVelocity = segVelocity + Physics.gravity * segTime;

            // Check to see if we're going to hit a physics object
            RaycastHit hit;

            if (Physics.Raycast(segments[i - 1], segVelocity, out hit, segmentScale))
            {
                // remember who we hit
                //Debug.Log("hit trajectory" + hit.collider.gameObject);
                _hitObject = hit.collider;

                // set next position to the position where we hit the physics object
                segments[i] = segments[i - 1] + segVelocity.normalized * hit.distance;
                // correct ending velocity, since we didn't actually travel an entire segment
                segVelocity = segVelocity - Physics.gravity * (segmentScale - hit.distance) / segVelocity.magnitude;
                // flip the velocity to simulate a bounce
                
                
                //incorect in some cases.is should be calculate using physicMaletials;
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
    private void PrepareForLaunch()//подготовка к запуску снаряда(появляется трек показывающий как полетит снаряд при таком расположении камеры )
    {
        //RenderTrajectory();
        launchPreparation.StartСountdown();
        preparationStart = true;
    }
    public void Launch()//запускаем снаряд
    {
        //создание снаряда и его запуск
        GameObject curProjectile= MonoBehaviour.Instantiate(projectile, weapon.transform.position + weapon.transform.forward, weapon.transform.rotation);
        curProjectile.GetComponent<Projectile>().isBase = false;
        curProjectile.GetComponent<Rigidbody>().AddForce(impulseLaunch*camera.transform.forward,ForceMode.Impulse);
    }
    public override void EndAttack()
    {
        launchStart = false;
        isActive = false;
        preparationStart = false;
    }
}
