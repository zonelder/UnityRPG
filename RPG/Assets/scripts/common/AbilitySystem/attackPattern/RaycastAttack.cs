using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastAttack : Attack
{
    private bool shootDone=false;
    private GameObject Cam;
    public GameObject weapon;
    private LineRenderer laserLine;
    private Cooldown lineRenderTime = new Cooldown(0.2f);
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
    public void Shoot()
    {

        Debug.Log("shoot start");
        // Create a vector at the center of our camera's viewport
        Vector3 rayOrigin = Cam.GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

        // Declare a raycast hit to store information about what our raycast has hit
        RaycastHit hit;
        laserLine.SetPosition(0, weapon.transform.position);
        if (Physics.Raycast(rayOrigin, Cam.GetComponent<Camera>().transform.forward, out hit, weaponRange))
        {
            // Set the end position for our laser line 
            laserLine.SetPosition(1, hit.point);

            // Get a reference to a health script attached to the collider we hit
            HittableEntity enemy = hit.collider.GetComponent<HittableEntity>();

            // If there was a health script attached
            if (enemy != null)
            {
                // Call the damage function of that script, passing in our gunDamage variable
                enemy.HitWillDone(weapon.transform.parent.gameObject,weapon);
               
                laserLine.SetPosition(1, hit.point);
            }
            lineRenderTime.Start—ountdown();
            laserLine.enabled = true;
        }
        else
        {
            laserLine.SetPosition(1, rayOrigin + (Cam.transform.forward * weaponRange));
        }
        
    }
    public override void EndAttack()
    {
        shootDone = false;
        isActive = false;
    }
   
}
