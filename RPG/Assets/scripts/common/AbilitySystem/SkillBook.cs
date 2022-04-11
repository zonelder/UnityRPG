using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBook : MonoBehaviour//все чем занимается этот класс это хранит и обновляет иформацию о способностях(все методы должны либо добавлять/убирать способности либо обновлять о них информацию(время до отката на пример))
{
    //тут еще можно добавить что было бы неплохо знать какая абилка из какой выхоидт что можно организоавть матрицей связности но пока вроде бы этому нужны нет
    public int size=0;
    public List<ActiveAbility> ability = new List<ActiveAbility>();//множетсво активных способностей

    public GameObject projectile;
    public void Start()//это уйдет вообще и появиться отдельный обьект для добавления
    {
        ActiveAbility NewAbility = new ActiveAbility(3);


        ProjectileAttack firstAttack1= new ProjectileAttack(gameObject);
        firstAttack1.property.SetAll(2.0f, 1.5f, 1.0f, 2.0f);//урон скорость скорость атаки длительность
        firstAttack1.SetProjectile(projectile);//пока что там уже ссылка на оружие игрокаы
        Attack secondAttack1 = new MeleeAttack(gameObject);
        NewAbility.AddAttack(firstAttack1);
        NewAbility.AddAttack(secondAttack1);
        AddAbility(NewAbility);

        ActiveAbility NewAbility2 = new ActiveAbility(10);
        Attack firstAttack2 = new RaycastAttack(gameObject);
        NewAbility2.AddAttack(firstAttack2);
        AddAbility(NewAbility2);

    }
    public void Update()
    {
        for(int i=0;i<size;++i)
        {
            if(!(ability[i].cooldown.IsReady()))//если скил в кд
            {
                ability[i].cooldown.TickTime(Time.deltaTime);// убавляем таймер
            }
        }
    }
    public ActiveAbility GetAbilityAt(int i)
    {
        return ability[i];
    }
    public void AddAbility(ActiveAbility newAbility)
    {
        size++;
        ability.Add(newAbility);//просто закидываем эту абилку в список без проверки на совпадения(если надо пусть носит разные варианты одной и той е способности
    }
    public void RemoveAbility(ActiveAbility newAbility)
    {
        size--;
        ability.Remove(newAbility);//удаляем абилку(может не работать в силу проверки по ссылке)
    }
    public void RemoveAt(int i)
    {
        size--;
        ability.RemoveAt(i);
    }
    public void CreateVoidAbility()
    {
        size++;
        ability.Add(new ActiveAbility(1));//создаем дефолтную пустышку которуб потом будет передавать в класс кастомайзер для настройик
    }


}
