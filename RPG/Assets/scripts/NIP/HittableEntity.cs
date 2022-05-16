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
       if (collision.gameObject.tag == "weapon")//тут спорная вещь я бы поменял
        {
            GameObject attaker = collision.gameObject.transform.parent.gameObject;//узнаем самого атакующего по его оружию
            HitWillDone(attaker, collision.gameObject.GetComponent<Weapon>());

        }        
    }


    public void Hit(float improvedDamage)
    {
        Debug.Log(Mathf.Floor(improvedDamage) + " damage done");
        Improved.HP.DistractFromCurrent(improvedDamage);
        
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
    public bool UnitDead() => Improved.HP.Current() <= 0;

    private void FloatingText(GameObject camera,DamageType type)
    {
        Vector3 TextOffset = -1.5f * camera.transform.right - 0.7f * camera.transform.up + 0.3f*Random.insideUnitSphere;
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
