using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes 
{
    //<attributes>
    public int STR;//����
    public int dextresity;//��������  
    public int intellect; //��������
    public int vitality;//���������
    public int will;//����
    public int luck;//�����
                    //��� ���� �������
                    //��� ���� �������
                    //</attributes>
    public Attributes()
    {
    }

    public Attributes(Attributes newAttr)
    {
        STR = newAttr.STR;
        dextresity = newAttr.dextresity;
        intellect = newAttr.intellect;
        vitality = newAttr.vitality;
        will = newAttr.will;
        luck = newAttr.luck;
        //
        //
    }
}
