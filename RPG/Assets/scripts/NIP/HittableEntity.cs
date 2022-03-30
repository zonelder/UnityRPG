using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittableEntity : MonoBehaviour//это все в какую нибудь обшивку пихнуть
{

    private void OnTriggerEnter(Collider collision)
    {
       if (collision.gameObject.tag == "weapon")//тут спорная хуйня я бы поменял
        {
            
             GameObject attaker = collision.gameObject.transform.parent.gameObject;//узнаем самого атакующего по его оружию
            if(attaker.tag== "Player")//вывод информации на дисплей в случае если это игрок
            {
                attaker.GetComponent<PlayerEnemyDisplay>().FightWith(gameObject);
            }
            Hit(collision.gameObject.GetComponent<Weapon>().CalculateDamage());
            if (UnitDead())
            {
                attaker.GetComponent<UnitStats>().GetExpFrom(GetComponent<UnitStats>());//если после нанесения урона хп мало то выдаем опыт убийце
            }

        }
       if(collision.gameObject.tag =="createdHitBox")
        {
            //надо чтобы на самом хитбокве висели все данные о нем в случае если игрок будет кастовать уже нечто другое а эта этака еще не закончиться
            //подобное можно сделать с и милишкой. если в оружие держать и обновлять информацию о свойствах атаки и ее особенностях
        }

        
    }

    public void Hit(float improvedDamage)
    {
        Debug.Log(Mathf.Floor(improvedDamage) + " damage done");
        GetComponent<UnitStats>().getDamage(improvedDamage);//наносим урон
        
    }

    public bool UnitDead() { return GetComponent<UnitStats>().curHP <= 0; }
}
