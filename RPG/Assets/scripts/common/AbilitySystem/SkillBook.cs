using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkillBook : MonoBehaviour
{
    // ��� ��� ���������� ���� ����� ��� ������ � ��������� ��������� � ������������.
    private int _size=0;
    [SerializeField]
    private List<ActiveAbility> _ability = new List<ActiveAbility>();

    public GameObject projectile;//�������� �����- ����� ������� ������� �������� ������
    public void Start()//��� ����� ������ � ��������� ��������� ������ ��� ����������
    {
        ActiveAbility NewAbility = new ActiveAbility(3);


        ProjectileAttack firstAttack1= new ProjectileAttack(gameObject);
        firstAttack1.Property.SetAll(2.0f, 1.5f, 1.0f, 2.0f);//���� �������� �������� ����� ������������
        firstAttack1.SetProjectile(projectile);
        Attack secondAttack1 = new MeleeAttack(gameObject);
        NewAbility.AddAttack(firstAttack1);
        NewAbility.AddAttack(secondAttack1);
        AddAbility(NewAbility);

        ActiveAbility NewAbility2 = new ActiveAbility(10);
        Attack firstAttack2 = new RaycastAttack(gameObject);
        ((RaycastAttack)firstAttack2).HitEffect = projectile.GetComponent<Projectile>().GetDestroyEffect();
        NewAbility2.AddAttack(firstAttack2);
        AddAbility(NewAbility2);

    }
    public void Update()
    {
        for(int i=0;i<_size;++i)
        {
            if(!(_ability[i].cooldown.IsReady()))//���� ���� � ��
            {
                _ability[i].cooldown.TickTime(Time.deltaTime);// �������� ������
            }
        }
    }
    public ActiveAbility GetAbilityAt(int i)
    {
        return _ability[i];
    }
    public void AddAbility(ActiveAbility newAbility)
    {
        _size++;
        _ability.Add(newAbility);
    }
    public void RemoveAbility(ActiveAbility newAbility)
    {
        _size--;
        _ability.Remove(newAbility);
    }
    public void RemoveAt(int i)
    {
        _size--;
        _ability.RemoveAt(i);
    }
    public void CreateVoidAbility()
    {
        _size++;
        _ability.Add(new ActiveAbility(1));
    }


}
