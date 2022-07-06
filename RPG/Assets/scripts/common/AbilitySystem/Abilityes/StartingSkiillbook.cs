using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingSkiillbook : MonoBehaviour
{
    [SerializeField] private GameObject _destroyEffect;
    [SerializeField] private Projectile _projectile;//временно сдесь- чтобы создать парочку примеров абилок
    [SerializeField] private SkillBook _skillBook;

    public void Start()
    {
        ActiveAbility NewAbility = new ActiveAbility(3);
        _projectile.DestroyBehaviour = new BlowAtPoint(5.0f, _destroyEffect);
        _projectile.TouchBehavoiur = new HitTouched();
        _projectile.MoveBehaviour = new TrajectoryMove();
        ((TrajectoryMove)_projectile.MoveBehaviour).Trajectory.trajectory.MoveKey(1, 1, new Vector3(0, 0, 1));
        ((TrajectoryMove)_projectile.MoveBehaviour).Trajectory.Duration.SetCooldown(_projectile.DelayBfDestroy.GetCooldown());
        ProjectileAttack firstAttack1 = new ProjectileAttack(gameObject);
        //                          урон скорость скорость атаки длительность
        firstAttack1.Property.SetAll(2.0f,2.0f);
        firstAttack1.Projectile = _projectile;
        Attack secondAttack1 = new MeleeAttack(gameObject);
        NewAbility.AddAttack(firstAttack1);
        NewAbility.AddAttack(secondAttack1);
        _skillBook.AddAbility(NewAbility);

        ActiveAbility NewAbility2 = new ActiveAbility(10);
        Attack firstAttack2 = new RaycastAttack(gameObject);
        // Что тестируем то и раскоменчиваем
        ((RaycastAttack)firstAttack2).ShootBehaviour= new BlowAtPoint(5.0f,_destroyEffect);
        //((RaycastAttack)firstAttack2).ShootBehaviour = new Teleportation();
        ((RaycastAttack)firstAttack2).AimBehaviour = new LinearAim();
        //((RaycastAttack)firstAttack2).AimBehaviour = new LinearIgnoreUnitsAim();
        //((RaycastAttack)firstAttack2).AimBehaviour = new LinearMustTouchedAim();

        NewAbility2.AddAttack(firstAttack2);
        _skillBook.AddAbility(NewAbility2);

    }
}
