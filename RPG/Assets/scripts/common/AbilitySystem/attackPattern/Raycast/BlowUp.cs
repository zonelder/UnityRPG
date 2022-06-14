using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowUp : IHit
{
    public float Radius;
    public GameObject HitEffect;
    public void Execute(Vector3 hitPoint)
    {
        //AttackBehaviour.BlowUp(hitPoint,Radius, OnAttack);

        if (HitEffect != null)
        {
            GameObject curEffect = MonoBehaviour.Instantiate(HitEffect,hitPoint,HitEffect.transform.rotation);//��������� ����� ������� ������������� ��� ����������� �������(���������� ����� ��� ���� ����)
            MonoBehaviour.Destroy(curEffect, 3.9f);
        }

    }
}
