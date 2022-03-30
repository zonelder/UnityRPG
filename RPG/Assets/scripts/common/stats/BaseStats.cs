using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace stats
{
    public class BaseStats//��� �� ������������� ������� ��������, � ������ ��������� ������� �������� ��� ������������� ������
    {
        //<abstract stats>
        public float HP;
        public float MP;//mind points
        public float SP;//speed point ��������� ������ ��������� ��������(���������� ����� �������� � ��)
        public float stamina;
        public float accuracy;//��������(������� ��� �������� � ����������� ���������+ ���������� �������� ��������� ��� ����� � ����������� �� ��������(��������� �������� ����� ��������� ��������������� �������))
        public float HPregen;//����������� ��
        public float MPregen;//����������� ��
        public float SPregen;//����� �������
        public float armor;
        public float armorRegen;
        public Attributes attributes = new Attributes();
        public BaseStats()//����� ���� ��� ����� public �� ����� ������������� ����� ����� ����� ������ ������ � ����� �� ������������� �������
        {

        }

        public BaseStats(int HP, int MP, int STR, int vitality, int intellect)
        {
            this.HP = HP;
            this.MP = MP;
            attributes.intellect = intellect;
            attributes.STR = STR;
            attributes.vitality = vitality;
        }
        public virtual void ChangeSTR(int d_STR)
        {
            attributes.STR += d_STR;
        }
        public virtual void ChangeDextresity(int d_dext)
        {
            attributes.dextresity += d_dext;
        }
        public virtual void ChangeIntellect(int d_int)
        {
            attributes.intellect += d_int;
        }
        public virtual void ChangeVitality(int d_vitality)
        {
            attributes.vitality += d_vitality;
        }

        public virtual void ChangeWill(int d_will)
        {
            attributes.will += d_will;
        }
        public virtual void ChangeLuck(int d_luck)
        {
            attributes.luck += d_luck;
        }

    }
}
