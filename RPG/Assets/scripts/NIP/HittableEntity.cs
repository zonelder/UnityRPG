using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittableEntity : UnitStats
{
    [SerializeField]
    private GameObject outgoingDamageText;
    [SerializeField]
    private GameObject outgoingCritText;


    public HittableEntity(int HP, int MP, int STR, int vitality, int energy):base(HP, MP, STR, vitality, energy) { }
    private void OnTriggerEnter(Collider collision)
    {
       if (collision.gameObject.tag == "weapon")//тут спорная хуйня я бы поменял
        {
            GameObject attaker = collision.gameObject.transform.parent.gameObject;//узнаем самого атакующего по его оружию
            HitWillDone(attaker, collision.gameObject.GetComponent<Weapon>());

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
        _improved.HP.DistractFromCurrent(improvedDamage);
        
    }
    public void HitWillDone(GameObject attaker, Weapon weapon)
    {
        if (attaker != gameObject)//сами себя не домажим
        {
            GeneratedDamage calculatedDamage = weapon.CalculateDamage();

            Hit(calculatedDamage);
            if (attaker.tag == "Player")//вывод информации на дисплей в случае если это игрок
            {
                    attaker.GetComponent<PlayerEnemyDisplay>().FightWith(gameObject);
             
                GameObject camera = attaker.transform.Find("playerCam").gameObject;
                FloatingText(camera, calculatedDamage.type);
                
            }
        }
        if (UnitDead())
        {
            attaker.GetComponent<UnitStats>().GetExpFrom(GetComponent<UnitStats>());//если после нанесения урона хп мало то выдаем опыт убийце
        }
    }
    public bool UnitDead() => _improved.HP.Current() <= 0;

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
        curText.GetComponent<TextLifeTime>().SetTextCarrier(gameObject, camera);
        curText.GetComponent<Canvas>().worldCamera = camera.GetComponent<Camera>();
        Destroy(curText, 2);
    }
}
