using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingSkiillbook : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;//временно сдесь- чтобы создать парочку примеров абилок
    [SerializeField] private SkillBook _skillBook;

    public void Start()//это уйдет вообще и появиться отдельный обьект для добавления
    {
        ActiveAbility NewAbility = new ActiveAbility(3);


        ProjectileAttack firstAttack1 = new ProjectileAttack(gameObject);
        firstAttack1.Property.SetAll(2.0f, 1.5f, 1.0f, 2.0f);//урон скорость скорость атаки длительность
        firstAttack1.SetProjectile(_projectile);
        Attack secondAttack1 = new MeleeAttack(gameObject);
        NewAbility.AddAttack(firstAttack1);
        NewAbility.AddAttack(secondAttack1);
        _skillBook.AddAbility(NewAbility);

        ActiveAbility NewAbility2 = new ActiveAbility(10);
        Attack firstAttack2 = new RaycastAttack(gameObject);
        ((RaycastAttack)firstAttack2).HitEffect = _projectile.GetComponent<Projectile>().GetDestroyEffect();
        NewAbility2.AddAttack(firstAttack2);
        _skillBook.AddAbility(NewAbility2);

    }
}
