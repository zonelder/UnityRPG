using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Cooldown delayBfDestroy = new Cooldown(3.0f);
    public GameObject destroyEffect;
    bool actionDone = false;
     public void Awake()
    {
        delayBfDestroy.Start�ountdown();
    }
    public void Update()
    {

        if(!delayBfDestroy.IsReady())
        delayBfDestroy.TickTime(Time.deltaTime);
        if (delayBfDestroy.IsReady() && !actionDone)//���� ������ ��� �������� � ����� ���� ���������
        {

            actionDone = true;
            OnDestroy();
        }
    }
    public void OnTouch()//��� ���������� ����� ������ �������� ��������� ��� ����������
    {

    }

    public void OnAttack()//��� ���������� ����� ����� ������� �������� �� ���������
    {

    }

    public void OnDestroy()
    {

        if(destroyEffect!=null)
        {
            Instantiate(destroyEffect, transform.position, transform.rotation);//��������� ����� ������� ������������� ��� ����������� �������
        }


        Debug.Log("destroy");

        Destroy(gameObject);
    }
}
