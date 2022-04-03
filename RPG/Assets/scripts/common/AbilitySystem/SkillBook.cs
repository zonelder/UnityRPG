using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBook : MonoBehaviour//все чем занимается этот класс это хранит и обновляет иформацию о способностях(все методы должны либо добавлять/убирать способности либо обновлять о них информацию(время до отката на пример))
{
    //тут еще можно добавить что было бы неплохо знать какая абилка из какой выхоидт что можно организоавть матрицей связности но пока вроде бы этому нужны нет
    public int size=0;
    public List<ActiveAbility> ability = new List<ActiveAbility>();//множетсво активных способностей
    public void Start()//это уйдет вообще и появиться отдельный обьект для добавления
    {
        ActiveAbility NewAbility = new ActiveAbility(10);


        Attack firstAttack= new MeleeAttack(gameObject);
        firstAttack.property.SetAll(2.0f, 1.5f, 1.0f, 4.0f);//урон скорость скорость атаки длительность
        firstAttack.shift.startTime = 1;
        firstAttack.shift.SetSpeed(5.0f,0.0f);
        firstAttack.shift.Set(new Vector3(-2,0,0));
        firstAttack.shift.RecalculateDuration();
        firstAttack.CalculateDuration();


        Attack secondAttack = new MeleeAttack(gameObject);
        secondAttack.property.SetAll(1.0f,1.5f,1.0f,2.0f);
        secondAttack.shift.SetSpeed(1.0f, 1.0f);
        secondAttack.shift.startTime = 0;
        secondAttack.shift.Set(new Vector3(4, 0, 0));
        secondAttack.shift.RecalculateDuration();
        secondAttack.CalculateDuration();


        Attack therdAttack = new MeleeAttack(gameObject);
        therdAttack.property.SetAll(5.0f,1.5f,1.0f,1.0f);
        therdAttack.shift.SetSpeed(0.0f,5.0f);
        therdAttack.shift.Set(new Vector3(0, 3, 0));
        therdAttack.shift.RecalculateDuration();
        therdAttack.CalculateDuration();


        NewAbility.AddAttack(firstAttack);
        NewAbility.AddAttack(secondAttack);
        NewAbility.AddAttack(therdAttack);
        AddAbility(NewAbility);

        ActiveAbility NewAbility2 = new ActiveAbility(10);
        firstAttack = new RaycastAttack(gameObject);
        NewAbility2.AddAttack(firstAttack);
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
