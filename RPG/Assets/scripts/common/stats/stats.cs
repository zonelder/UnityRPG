using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace stats
{//����� ��������� �������� � �����������. ����� �����
    public class Stats: BaseStats//�������� � ������� ��� ������
    {

        public Cooldown armorRecovery;//������ �� ������ ������(���� ��� �� ���������)

        public Damage damage = new Damage();//�� ���� ������ ������ ���� � ����������. �������� ��������� ������� ���������� �����(�� ������ ���)
        //�� �� ���������� ���� ����� � ��� ���������

        public Stats(BaseStats baseStats)
        {

        }


        public Stats(int HP, int MP, int STR, int vitality, int intellect)
        {
            this.HP = HP;
            this.MP = MP;
            attributes.intellect = intellect;
            attributes.STR = STR;
            attributes.vitality = vitality;
 
        }

        /// <�������_��_����_��������>
        /// /��� ��������� ������ ������� ��������� ������� ��������� ������, ������� ������ ������ ��������. � ����� ������� ���������� ��������� �������������
        /// </�������_��_����_��������>
        public override void ChangeSTR(int d_STR)
        {
            base.ChangeSTR(d_STR);
            damage.ChangeDamage(d_STR * 1.5f, d_STR * 1.5f);//������ ���� �� ����.�� ��� �������� 
        }
        public override void ChangeDextresity(int d_dext)
        {
            base.ChangeDextresity(d_dext);
            //something to secondatyStats
        }
        public override void ChangeIntellect(int d_int)
        {
            base.ChangeIntellect(d_int);
            //something to secondary stats
        }
        public override void ChangeVitality(int d_vitality)
        {
            base.ChangeVitality(d_vitality);
            HP += Mathf.Floor(d_vitality * 3.6f);//HP �� ������� ���������
            HPregen += Mathf.Floor(d_vitality * 1.2f);//����������� �� �� ��������� 
        }
        public override void ChangeWill(int d_will)
        {
            base.ChangeWill(d_will);
            MP += Mathf.Floor(d_will * 1.1f);//�� �� ������� ����
            MPregen += Mathf.Floor(d_will * 0.5f);//����� �� ������� ����
        }
        public override void ChangeLuck(int d_luck)
        {
            base.ChangeLuck(d_luck);
            damage.critChan�e += Mathf.Floor(d_luck*2.3f);//2.3 �������� ����� �� ������� ������� �����
        }


   
       
    }
}