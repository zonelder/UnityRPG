using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittableEntity : MonoBehaviour
{
    public float curHP; //���-�� ������ �������� ��������
    public float curMP; //���-�� ���� ���������
    [SerializeField]
    private GameObject outgoingDamageText;
    [SerializeField]
    private GameObject outgoingCritText;
    private void OnTriggerEnter(Collider collision)
    {
       if (collision.gameObject.tag == "weapon")//��� ������� ����� � �� �������
        {
            GameObject attaker = collision.gameObject.transform.parent.gameObject;//������ ������ ���������� �� ��� ������
            HitWillDone(attaker, collision.gameObject.GetComponent<Weapon>());

        }
       if(collision.gameObject.tag =="createdHitBox")
        {
            //���� ����� �� ����� �������� ������ ��� ������ � ��� � ������ ���� ����� ����� ��������� ��� ����� ������ � ��� ����� ��� �� �����������
            //�������� ����� ������� � � ��������. ���� � ������ ������� � ��������� ���������� � ��������� ����� � �� ������������
        }

        
    }


    public void Hit(float improvedDamage)
    {
        Debug.Log(Mathf.Floor(improvedDamage) + " damage done");
        curHP -= improvedDamage;
        
    }
    public void HitWillDone(GameObject attaker, Weapon weapon)
    {
        if (attaker != gameObject)//���� ���� �� �������
        {
            GeneratedDamage calculatedDamage = weapon.CalculateDamage();

            Hit(calculatedDamage);
            if (attaker.tag == "Player")//����� ���������� �� ������� � ������ ���� ��� �����
            {
                    attaker.GetComponent<PlayerEnemyDisplay>().FightWith(gameObject);
             
                GameObject camera = attaker.transform.Find("playerCam").gameObject;
                FloatingText(camera, calculatedDamage.type);
                
            }
        }
        if (UnitDead())
        {
            attaker.GetComponent<UnitStats>().GetExpFrom(GetComponent<UnitStats>());//���� ����� ��������� ����� �� ���� �� ������ ���� ������
        }
    }
    public bool UnitDead() => curHP <= 0;

    private void FloatingText(GameObject camera,DamageType type)
    {
        Vector3 TextOffset = -1.5f * camera.transform.right - 0.7f * camera.transform.up + new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(-0.3f, 0.3f), Random.Range(-0.3f, 0.3f));
        //custom value
        //<create copy of needed text>
        GameObject curText;
        if (type == DamageType.common)
            curText = Instantiate(outgoingDamageText, gameObject.transform.position + TextOffset, camera.transform.rotation);
        else
            //if(calculatedDamage.type == DamageType.crit)
            curText = Instantiate(outgoingCritText, gameObject.transform.position + TextOffset, camera.transform.rotation);
        ///crete copy of needed text>
        curText.GetComponent<TextLifeTime>().camera = camera;
        curText.GetComponent<TextLifeTime>().targetUnit = gameObject;
        curText.GetComponent<Canvas>().worldCamera = camera.GetComponent<Camera>();
        Destroy(curText, 2);
    }
}
