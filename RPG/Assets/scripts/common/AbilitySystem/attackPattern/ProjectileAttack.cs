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

public class ProjectileAttack : Attack//���� �������� ���������. ���� ������� ��� �����, ����� �������� ����� ��� ���
{
    private ProjectileState pState;
    private LineRenderer sightLine;
    private float impulseLaunch = 10.0f;
    private float launchTime = 0;//����� ������������ ������ ����� ����� ���� ��������� ������
    private Cooldown launchPreparation;//����� ���������� � ������� �������
    private GameObject projectile;//��������� � ����� �������-�� ������ ����� ��� ������
    private GameObject weapon;// ������� ��������������.������������ ������ ����� �����������
    private GameObject camera;// ��������� � ����� ������- �� ������ ����� ���� ������
   public ProjectileAttack(GameObject user)
    {
        weapon = user.transform.Find("weapon").gameObject;//����� ���� ���
        camera = user.transform.Find("playerCam").gameObject;
        launchPreparation= new Cooldown(1.0f);//���� ������� ����� ����������
        sightLine = weapon.GetComponent<LineRenderer>();
    }
    public void SetProjectile(GameObject newProjectile)//������ ����� �����
    {
        projectile = newProjectile;
        projectile.GetComponent<Projectile>().isBase = true;
        projectile.GetComponent<Projectile>().projectileStats = weapon.GetComponent<Weapon>();
        projectile.GetComponent<Projectile>().user = weapon.transform.parent.gameObject;
    }
 
    public override void StartAttack()
    {
        //isActive = true;
        base.StartAttack();
        pState = ProjectileState.BEFORE_PREPARATION;
    }

    public override void TickTime(float delta, float SpeedAmp = 1)
    {
        base.TickTime(delta,SpeedAmp);
        if (property.duration.curTime() > launchTime && pState == ProjectileState.BEFORE_PREPARATION )
        {
            pState = ProjectileState.PREPARATION;
            PrepareForLaunch();
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
    private void PrepareForLaunch()//���������� � ������� �������(���������� ���� ������������ ��� ������� ������ ��� ����� ������������ ������ )
    {
        launchPreparation.Start�ountdown();
    }
    public void Launch()//��������� ������
    {
        //�������� ������� � ��� ������
        GameObject curProjectile= MonoBehaviour.Instantiate(projectile, weapon.transform.position + weapon.transform.forward, weapon.transform.rotation);
        curProjectile.GetComponent<Projectile>().isBase = false;
        curProjectile.GetComponent<Rigidbody>().AddForce(impulseLaunch*camera.transform.forward,ForceMode.Impulse);

        pState = ProjectileState.AFTER_LAUNCH;
    }
    public override void EndAttack()
    {
        //isActive = false;
        base.EndAttack();
    }
}
