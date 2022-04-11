using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //<����� ������� ���������� ������������ ��������� �������>
   //����� ���� � ������� �� ����� ���� �������� � ��������� �� � ��������� �����  � ������������� ������� state ��� ������ projectile
    public bool isBase = false;
    public bool createCopiesOnDestroy = true;
    bool actionDone = false;
    //</����� ������� ���������� ������������ ��������� �������>
    public GameObject user;
    public Weapon projectileStats;
    public Cooldown delayBfDestroy = new Cooldown(3.0f);
    public GameObject destroyEffect;
    public float radius = 5.0f;
   
     public void Awake()
    {
        actionDone = false;
        delayBfDestroy.Start�ountdown();
    }
    public void Update()
    {
        if (!isBase)
        {
            if (!delayBfDestroy.IsReady())

            {
                delayBfDestroy.TickTime(Time.deltaTime);
                onFly();
            }
            if (delayBfDestroy.IsReady() && !actionDone)//���� ������ ��� �������� � ����� ���� ���������
            {

                OnEndLiveTime();
                actionDone = true;
            }
        }
    }
    public void OnTouch(GameObject tangentSurface)//��� ���������� ����� ������ �������� ��������� ��� ����������
    {
        Debug.Log(gameObject.name + " Touch "+tangentSurface.name);
        OnAttackWhenTouch(tangentSurface);
        //Instantiate(gameObject, transform.position, transform.rotation);
    }

    public void OnAttack(GameObject beaten)//��� ���������� ����� ����� ������� �������� �� ���������
    {
        //��������� �����.
        HittableEntity beatenEntity = beaten.GetComponent<HittableEntity>();
        if (beatenEntity != null)
            beatenEntity.HitWillDone(user, projectileStats);
        //��� ���� ������. ����� ��������� �� OnAttaackWhenTouch
        //OnAttackWhenDestroy
        //OnAttackWhenFly;
    }
    public void OnAttackWhenTouch(GameObject obj)
    {
        if (obj.tag == "Unit")//� ������� ���� ��������� �����
        {
            Debug.Log("encounter a " + obj.name);
            obj.GetComponent<HittableEntity>().Hit(10.0f);//�������� ���� �� �����
            //������� �������������� �� �������. ���� �������� ��� ����� ������ ��������� ��������������

        }
        
    }
    public void OnEndLiveTime()
    {
       
        //<blow up when destroy>
        //delegate void AttackPattern(GameObject beaten);
        //AttackPattern AttackForThisCase = OnAttack;
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in colliders)
        {  
            if (nearbyObject.isTrigger==true)
            {

                //AttackForThisCase(nearbyObject.gameObject);
                OnAttack(nearbyObject.gameObject);
            }

        }//</blow up when destroy>

        //<create coppies of another object>
        if(createCopiesOnDestroy)
         for(int i=0;i<3;i++)
        {
            GameObject objectAfterDestory = gameObject;
            Vector3 randomVector = new Vector3(Random.value, Random.value, Random.value);
            GameObject copyProjectile = Instantiate(objectAfterDestory, objectAfterDestory.transform.position + randomVector, objectAfterDestory.transform.rotation);
            copyProjectile.GetComponent<Projectile>().createCopiesOnDestroy = false;
            randomVector = new Vector3(Random.value, 2, Random.value);
            copyProjectile.GetComponent<Rigidbody>().AddForce(5*randomVector, ForceMode.Impulse);
        }
        //</create copies of original>


        //<base module for projectile>
        if (destroyEffect != null)
        {
            GameObject curEffect = Instantiate(destroyEffect, transform.position, transform.rotation);//��������� ����� ������� ������������� ��� ����������� �������(���������� ����� ��� ���� ����)
            Destroy(curEffect, 3.9f);
        }
        Debug.Log("destroy");
        Destroy(gameObject);
        //</base module for projectile>


    }
    private void onFly()
    {
        
    }
    private void OnCollisionEnter(Collision coll)
    {
        OnTouch(coll.gameObject);
    }
}
